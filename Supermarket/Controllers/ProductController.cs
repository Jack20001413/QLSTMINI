using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Application.Interfaces;
using Application.DTOs;

namespace Supermarket.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;

        public ProductController(
            IProductService productService,
            IBrandService brandService,
            ICategoryService categoryService)
        {
            this.productService = productService;
            this.brandService = brandService;
            this.categoryService = categoryService;
        }

        
        [BindProperty]
        public ProductDto Product { get; set; }

        public IActionResult Index()
        {   
            return View(productService.GetAll());
        }
           
        public IActionResult AddOrEdit(int id)
        {   
            ViewBag.Category = new SelectList( categoryService.GetAll(), "Id", "Name");
            ViewBag.Brand = new SelectList( brandService.GetAll(), "Id", "Name");
            if (id == 0)
            {   
                return View(new ProductDto());
            }
            else
            {
                var product = productService.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, ProductDto product)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {   
                    product.Category = categoryService.GetCategory(product.CategoryId);
                    product.Brand = brandService.GetBrand(product.BrandId);
                    productService.CreateProduct(product);
                }
                else
                {
                    try
                    {
                        product.Category = categoryService.GetCategory(product.CategoryId);
                        product.Brand = brandService.GetBrand(product.BrandId);
                        productService.UpdateProduct(product);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!productService.ProductExists(product.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                var products = productService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", products) });
            }

            ViewBag.Category = new SelectList( categoryService.GetAll(), "Id", "Name");
            ViewBag.Brand = new SelectList( brandService.GetAll(), "Id", "Name");

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit",product) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var product = productService.GetProduct(id);
            productService.DeleteProduct(product);

            var products = productService.GetAll();    
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", products) });
        }
    }

}
