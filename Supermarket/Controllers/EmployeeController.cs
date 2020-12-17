using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Application.Interfaces;
using Application.DTOs;
using System.Text;
using System;

namespace Supermarket.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IEmployeeGroupService employeeGroupService;

        public EmployeeController(IEmployeeGroupService employeeGroupService, IEmployeeService employeeService)
        {
            this.employeeGroupService = employeeGroupService;
            this.employeeService = employeeService;
        }
        
        [BindProperty]
        public EmployeeDto employee { get; set; }

// Tạo giao diện
        public IActionResult Index()
        {   
            return View(employeeService.GetAll());
        }
          
        public IActionResult AddOrEdit(int id)
        {   
            ViewBag.EmployeeGroup = new SelectList( employeeGroupService.GetAll(), "Id", "Name");
            if (id == 0)
            {   
                return View(new EmployeeDto());
            }
            else
            {
                var employee = employeeService.GetEmployee(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, EmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {   
                    employee.EmployeeGroup = employeeGroupService.GetEmployeeGroup(employee.EmployeeGroupId);
                    employee.Password = Encrypt(employee.Password);
                    employeeService.CreateEmployee(employee);
                }
                else
                {
                    try
                    {
                        employee.EmployeeGroup = employeeGroupService.GetEmployeeGroup(employee.EmployeeGroupId);

                        employeeService.UpdateEmployee(employee);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!employeeService.IsEmployeeExisted(employee.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                var employees = employeeService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", employees.ToList()) });
            }

            ViewBag.EmployeeGroup = new SelectList( employeeGroupService.GetAll(), "Id", "Name");

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", employee) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var employee = employeeService.GetEmployee(id);
            employeeService.DeleteEmployee(employee);

            var employees = employeeService.GetAll();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", employees) });
        }

        public static string Key= "qlstmini@gmail.com";
        public static string Encrypt(string password)
        {
            if(string.IsNullOrEmpty(password))
            return "";
            password+= Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
       
    }

}