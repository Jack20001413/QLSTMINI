using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Supermarket;
using Application.Interfaces;
using Application.DTOs;

namespace Controllers
{
    public class ImportingOrderController : Controller
    {
        private readonly IImportingOrderService importingOrderService;
        private readonly IVendorService vendorService;
        private readonly IEmployeeService employeeService;
        private readonly IProductService productService;
        public ImportingOrderController(IImportingOrderService importingOrderService, IVendorService vendorService, IEmployeeService employeeService, IProductService productService)
        {
            this.importingOrderService = importingOrderService;
            this.vendorService = vendorService;
            this.employeeService = employeeService;
            this.productService = productService;
        }

        [BindProperty]
        public ImportingOrderDto ImportingOrder { get; set; }

        public IActionResult Index()
        {   
            return View(importingOrderService.GetAll());
        }
        
        public IActionResult Add()
        {
            ViewBag.Vendors = new SelectList( vendorService.GetAll(), "Id", "Name");
            ViewBag.Employees = new SelectList( employeeService.GetAll(), "Id", "Fullname");

            return View(new ImportingOrderDto());
        }

        [HttpPost]
        public IActionResult Add(ImportingOrderDto order)
        {
            if(ModelState.IsValid)
            {
                order.Vendor = vendorService.GetVendor(order.VendorId);
                order.Employee = employeeService.GetEmployee(order.EmployeeId);

                importingOrderService.CreateOrder(order);
            }

            ViewBag.Vendor = new SelectList( vendorService.GetAll(), "Id", "Name");
            ViewBag.Employees = new SelectList( employeeService.GetAll(), "Id", "Fullname");

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add",order) });
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Vendors = new SelectList( vendorService.GetAll(), "Id", "Name");
            ViewBag.Employees = new SelectList( employeeService.GetAll(), "Id", "Fullname");
            
            var order = importingOrderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(ImportingOrderDto order)
        {
            if(ModelState.IsValid)
            {
                try
                {   
                    importingOrderService.UpdateOrder(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!importingOrderService.OrderExists(order.Id))
                    { return NotFound(); }
                    else
                    { throw; }
                }
                var orders = importingOrderService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", orders.ToList()) });
            }

            ViewBag.Vendor = new SelectList( vendorService.GetAll(), "Id", "Name");
            ViewBag.Employees = new SelectList( employeeService.GetAll(), "Id", "Fullname");

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit",order) });
        }

        private bool OrderExists(int id)
        {
            var order = importingOrderService.GetOrder(id);
            return order != null;
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var order = await _db.ImportingOrders.FindAsync(id);
        //     _db.ImportingOrders.Remove(order);
        //     await _db.SaveChangesAsync();

        //     var orders = _db.ImportingOrders.Include(o => o.Vendor).Include(o => o.Employee);
        //     return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", orders.ToList()) });
        // }


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