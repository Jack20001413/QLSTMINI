using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [BindProperty]
        public CategoryDto Category { get; set; }

       public IActionResult Index()
        {   
            return View(categoryService.GetAll());
        }

       public IActionResult AddOrEdit(int id)
        {    
            if (id == 0)
            {   
                return View(new CategoryDto());
            }
            else
            {
                var category = categoryService.GetCategory(id);
                if ( category== null)
                {
                    return NotFound();
                }
                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {   
                    categoryService.CreateCategory(category);
                }
                else
                {
                    try
                    {
                        categoryService.UpdateCategory(category);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!categoryService.CategoryExists(category.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                var categories = categoryService.GetAll();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", categories )});
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit",category) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = categoryService.GetCategory(id);
            categoryService.DeleteCategory(category);

            var categories = categoryService.GetAll();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", categories) });
        }

       
    }
}
 