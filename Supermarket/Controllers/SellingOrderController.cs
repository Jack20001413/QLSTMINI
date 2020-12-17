using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Supermarket;

namespace Controllers
{
    public class SellingOrderController : Controller
    {
        private readonly ISellingOrderService sellingOrderService;
        private readonly ICustomerService customerService;
        private readonly IEmployeeService employeeService;
        private readonly IProductService productService;

        public SellingOrderController(ISellingOrderService sellingOrderService,
                                IProductService productService,
                                IEmployeeService employeeService,
                                ICustomerService customerService)
        {
            this.sellingOrderService = sellingOrderService;
            this.employeeService = employeeService;
            this.customerService = customerService;
            this.productService = productService;
        }

        [BindProperty]
        public SellingOrderDto SellingOrder { get; set; }

        public IActionResult Index()
        {
            return View(sellingOrderService.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Customers = new SelectList( customerService.GetAll(), "Id", "Fullname");
            ViewBag.Employees = new SelectList( employeeService.GetAll(), "Id", "Fullname");

            return View(new SellingOrderDto());
        }


        [HttpPost]
        public IActionResult Add(SellingOrderDto order)
        {
            if(ModelState.IsValid)
            {
                order.Customer = customerService.GetCustomer(order.CustomerId);
                order.Employee = employeeService.GetEmployee(order.EmployeeId);

                sellingOrderService.CreateOrder(order);
            }

            ViewBag.Customers = new SelectList( customerService.GetAll(), "Id", "Fullname");
            ViewBag.Employees = new SelectList( employeeService.GetAll(), "Id", "Fullname");

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add",order) });
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Customers = new SelectList( customerService.GetAll(), "Id", "Fullname");
            ViewBag.Employees = new SelectList( employeeService.GetAll(), "Id", "Fullname");
            
            var order = sellingOrderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(SellingOrderDto order)
        {
            if(ModelState.IsValid)
            {
                try
                {   
                    sellingOrderService.UpdateOrder(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sellingOrderService.OrderExists(order.Id))
                    { return NotFound(); }
                    else
                    { throw; }
                }
                var orders = sellingOrderService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", orders.ToList()) });
            }

            ViewBag.Customers = new SelectList( customerService.GetAll(), "Id", "Fullname");
            ViewBag.Employees = new SelectList( employeeService.GetAll(), "Id", "Fullname");

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit",order) });
        }

        [HttpGet]
        public JsonResult Search(string parm) {
            // Replace your special Character like "-,~" etc from your search string
            var result = new List < KeyValuePair < string,
                string >> ();
            /*foreach(var item in _obj_fulldetails.GetCompanylistSearch(parm)) {
                result.Add(new KeyValuePair < string, string > (item.Value.ToString(), item.Text));
            }*/
            //string term = HttpContext.Request.Query["term"].ToString();
            var product = productService.Search(parm);
            return Json(product);
        }
    }
}