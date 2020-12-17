using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Controllers
{
    [Authorize]
    public class EmployeeGroupController : Controller
    {
        private readonly IEmployeeGroupService employeeGroupService;

        public EmployeeGroupController(IEmployeeGroupService employeeGroupService)  
        {
            this.employeeGroupService = employeeGroupService;
        }

        [BindProperty]
        public EmployeeGroupDto EmployeeGroup { get; set; }

        public IActionResult Index()
        {   
            return View(employeeGroupService.GetAll());
        }

        public IActionResult AddOrEdit(int id)
        {  
            if (id == 0)
            {   
                return View(new EmployeeGroupDto());
            }
            else
            {
                var employeegroup = employeeGroupService.GetEmployeeGroup(id);
                if (employeegroup == null)
                {
                    return NotFound();
                }
                return View(employeegroup);
            }
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, EmployeeGroupDto employeegroup)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {   

                    employeeGroupService.CreateEmployeeGroup(employeegroup);
                }
                else
                {
                    try
                    {
                        employeeGroupService.UpdateEmployeeGroup(employeegroup);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!employeeGroupService.EmployeeGroupExists(employeegroup.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                var employeegroups = employeeGroupService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", employeegroups) });
            }
            

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit",employeegroup) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var employeegroup = employeeGroupService.GetEmployeeGroup(id);
            employeeGroupService.DeleteEmployeeGroup(employeegroup);

            var employeegroups = employeeGroupService.GetAll();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", employeegroups) });
        }


       
    }

} 
 