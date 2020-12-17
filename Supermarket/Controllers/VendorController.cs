using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket;


namespace Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorService vendorService;

        public VendorController(IVendorService vendorService)
        {
            this.vendorService = vendorService;
        }

        [BindProperty]
        public VendorDto Vendor { get; set; }

        public IActionResult Index()
        {   
            return View(vendorService.GetAll());
        }

        public IActionResult AddOrEdit(int id)
        {
            if (id == 0)
            {   
                return View(new VendorDto());
            }
            else
            {
                var vendor = vendorService.GetVendor(id);
                if (vendor== null)
                {
                    return NotFound();
                }
                return View(vendor);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, VendorDto vendor)
        {
         
            if (ModelState.IsValid)
            {
                if (id == 0)
                {   

                    vendorService.CreateVendor(vendor);
                }
                else
                {
                    try
                    {
                        vendorService.UpdateVendor(vendor);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!vendorService.VendorExists(vendor.Id))
                        { return NotFound(); }

                        else

                        { throw; }
                    }
                }
                var vendors = vendorService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", vendors) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit",vendor) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var vendor = vendorService.GetVendor(id);
            vendorService.DeleteVendor(vendor);

            var vendors = vendorService.GetAll();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", vendors )});
        }















        // [HttpPost]
        // public IActionResult Insert()
        // {
        //     if(ModelState.IsValid)
        //     {
        //         _db.Vendors.Add(Vendor);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToAction("Index");
        // }

        // [HttpDelete]
        // public IActionResult Delete()
        // {
        //     var vendorNeeded = _db.Vendors.Find(Vendor.Id);
        //     if(ModelState.IsValid)
        //     {
        //         _db.Vendors.Remove(vendorNeeded);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToAction("Index");
        // }

        // [HttpPut]
        // public IActionResult Update()
        // {
        //     if(ModelState.IsValid)
        //     {
        //         _db.Vendors.Update(Vendor);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToPage("Index");

        // }




    }
}