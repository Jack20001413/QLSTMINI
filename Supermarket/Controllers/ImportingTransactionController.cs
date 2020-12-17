using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    public class ImportingTransactionController : Controller
    {
        // private readonly SupermarketDbContext _db;

        // public ImportingTransactionController(SupermarketDbContext db)
        // {
        //     _db = db;
        // }

        // [BindProperty]
        // public ImportingTransactionDto ImportingTransaction { get; set; }

        // public async Task<IActionResult> Index(int id)
        // {   
        //     var trans = _db.ImportingTransactions.Where(t => t.ImportingOrder.Id == id).Include(t => t.ImportingOrder);
        //     return View(await trans.ToListAsync());
        // }

        // public async Task<IActionResult> AddOrEdit(int id)
        // {   
        //     ViewBag.CustomerGroup = new SelectList( await _db.CustomerGroups.ToListAsync(), "Id", "Name");
        //     if (id == 0)
        //     {   
        //         return View(new Customer());
        //     }
        //     else
        //     {
        //         var customer = await _db.Customers.FindAsync(id);
        //         if (customer == null)
        //         {
        //             return NotFound();
        //         }
        //         return View(customer);
        //     }
        // }

        // [HttpDelete]
        // public IActionResult Delete()
        // {
        //     var importingTransactionNeeded = _db.ImportingTransactions.Find(ImportingTransaction.Id);
        //     if(ModelState.IsValid)
        //     {
        //         _db.ImportingTransactions.Remove(importingTransactionNeeded);
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
        //         _db.ImportingTransactions.Update(ImportingTransaction);
        //         _db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToPage("Index");
        // }
    }
}