using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Application.Interfaces;
using Application.DTOs;

namespace Supermarket.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly ICustomerGroupService customerGroupService;

        public CustomerController(ICustomerService customerService,ICustomerGroupService customerGroupService)
        {
            this.customerService = customerService;
            this.customerGroupService = customerGroupService;
        }

        
        [BindProperty]
        public CustomerDto Customer { get; set; }

// Tạo giao diện
        public IActionResult Index()
        {   
           return View(customerService.GetAll());
        }

           
        public IActionResult AddOrEdit(int id)
        {   
            ViewBag.CustomerGroup = new SelectList( customerGroupService.GetAll(), "Id", "Name");
            if (id == 0)
            {   
                return View(new CustomerDto());
            }
            else
            {
                var customer = customerService.GetCustomer(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, CustomerDto customer)
        {
            // var id1 = this.GetGroupId(customer);
            if (ModelState.IsValid)
            {
                if (id == 0)
                {   
                    customer.CustomerGroup = customerGroupService.GetCustomerGroup(customer.CustomerGroupId);

                    customerService.CreateCustomer(customer);
                }
                else
                {
                    try
                    {
                        customer.CustomerGroup = customerGroupService.GetCustomerGroup(customer.CustomerGroupId);

                        customerService.UpdateCustomer(customer);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!customerService.IsCustomerExisted(customer.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                var customers = customerService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", customers) });
            }

            ViewBag.CustomerGroup = new SelectList(customerGroupService.GetAll(), "Id", "Name");

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit",customer) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var customer = customerService.GetCustomer(id);
            customerService.DeleteCustomer(customer);

            var customers = customerService.GetAll();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", customers) });
        }


       
    }

}
