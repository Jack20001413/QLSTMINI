using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Supermarket.Controllers
{
    [Authorize]
    public class CustomerGroupController : Controller
    {
        private readonly ICustomerGroupService customerGroupService;

        public CustomerGroupController(ICustomerGroupService customerGroupService)
        {
            this.customerGroupService = customerGroupService;
        }

        [BindProperty]
        public CustomerGroupDto CustomerGroup { get; set; }

       public IActionResult Index()
        {   
            return View(customerGroupService.GetAll());
        }
    
 

       public IActionResult AddOrEdit(int id)
        {   
            if (id == 0)
            {   
                return View(new CustomerGroupDto());
            }
            else
            {
                var customergroup = customerGroupService.GetCustomerGroup(id);
                if (customergroup == null)
                {
                    return NotFound();
                }
                return View(customergroup);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, CustomerGroupDto customergroup)
        {
            // var id1 = this.GetGroupId(customer);
            if (ModelState.IsValid)
            {
                if (id == 0)
                {   
                    customerGroupService.CreateCustomerGroup(customergroup);
                }
                else
                {
                    try
                    {
                    customerGroupService.UpdateCustomerGroup(customergroup);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!customerGroupService.CustomerGroupExists(customergroup.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                var customergroups = customerGroupService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", customergroups) });
            }
            
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit",customergroup) });
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var customergroup = customerGroupService.GetCustomerGroup(id);
            customerGroupService.DeleteCustomerGroup(customergroup);

            var customergroups = customerGroupService.GetAll();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", customergroups) });
        }

       
    }
}
 