using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Supermarket.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;
        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [BindProperty]
        public BrandDto Brand { get; set; }

       public IActionResult Index()
        {   
            return View(brandService.GetAll());
        }
    
       public IActionResult AddOrEdit(int id)
        {      
            if (id == 0)
            {   
                return View(new BrandDto());
            }
            else
            {
                //tim dong du lieu theo khoa chinh
                var brand = brandService.GetBrand(id);
                if ( brand== null)
                {
                    return NotFound();
                }
                return View(brand);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, BrandDto brand)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {   
                    brandService.CreateBrand(brand);
                }
                else
                {
                    try
                    {
                        brandService.UpdateBrand(brand);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!brandService.BrandExists(brand.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                var brands = brandService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", brands) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit",brand) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var brand = brandService.GetBrand(id);
            brandService.DeleteBrand(brand);

            var brands = brandService.GetAll();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", brands) });
        }

       
    }
}
 