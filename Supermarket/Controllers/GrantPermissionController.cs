using Application.DTOs;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class GrantPermissionController : Controller
    {
        // private readonly SupermarketDbContext _db;

        // public GrantPermissionController(SupermarketDbContext db)
        // {
        //     _db = db;
        // }

        // [BindProperty]
        // public GrantPermissionDto GrantPermission { get; set; }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public IActionResult Insert()
        // {
        //     if(ModelState.IsValid)
        //     {
        //         _db.GrantPermissions.Add(GrantPermission);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToAction("Index");
        // }

        // [HttpDelete]
        // public IActionResult Delete()
        // {
        //     var grantPermissionNeeded = _db.GrantPermissions.Find(GrantPermission.Id);
        //     if(ModelState.IsValid)
        //     {
        //         _db.GrantPermissions.Remove(grantPermissionNeeded);
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
        //         _db.GrantPermissions.Update(GrantPermission);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToPage("Index");
        // }
    }
}