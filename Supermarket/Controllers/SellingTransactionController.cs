using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class SellingTransactionController : Controller
    {
        // private readonly SupermarketDbContext _db;

        // public SellingTransactionController(SupermarketDbContext db)
        // {
        //     _db = db;
        // }

        // [BindProperty]
        // public SellingTransaction SellingTransaction { get; set; }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public IActionResult Insert()
        // {
        //     if(ModelState.IsValid)
        //     {
        //         _db.SellingTransactions.Add(SellingTransaction);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToAction("Index");
        // }

        // [HttpDelete]
        // public IActionResult Delete()
        // {
        //     var sellingTransactionNeeded = _db.SellingTransactions.Find(SellingTransaction.Id);
        //     if(ModelState.IsValid)
        //     {
        //         _db.SellingTransactions.Remove(sellingTransactionNeeded);
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
        //         _db.SellingTransactions.Update(SellingTransaction);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToPage("Index");
        // }
    }
}