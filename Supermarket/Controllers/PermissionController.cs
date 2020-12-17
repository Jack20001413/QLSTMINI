using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class PermissionController : Controller
    {
        // private readonly SupermarketDbContext _db;

        // public PermissionController(SupermarketDbContext db)
        // {
        //     _db = db;
        // }

        // [BindProperty]
        // public Permission Permission { get; set; }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public IActionResult Insert()
        // {
        //     if(ModelState.IsValid)
        //     {
        //         _db.Permissions.Add(Permission);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToAction("Index");
        // }

        // [HttpDelete]
        // public IActionResult Delete()
        // {
        //     var permissionNeeded = _db.Permissions.Find(Permission.Code);
        //     if(ModelState.IsValid)
        //     {
        //         _db.Permissions.Remove(permissionNeeded);
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
        //         _db.Permissions.Update(Permission);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToPage("Index");
        // }
    }
}