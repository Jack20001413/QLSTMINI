using System;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
// using Supermarket.ViewModel;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Controllers
{
    [Authorize]
    public class RevenueStatisticsController: Controller
    {
        private readonly ISellingOrderService sellingOrderService;

        public RevenueStatisticsController(ISellingOrderService sellingOrderService)
        { 
            this.sellingOrderService = sellingOrderService;
        }
          
        [HttpGet]
        public IActionResult Index(DateTime? StartDate, DateTime? EndDate)
         {   
            //goi doi tuong  RevenueStatistics va gan tham so vao cac gia tri
            RevenueStatistics revenue = new RevenueStatistics();
            revenue.startDate = StartDate; 
            revenue.endDate = EndDate; 
            //revenue.sellingOrders = _db.SellingOrders.Include(r => r.Customer).Include(r => r.Employee).AsQueryable();
            revenue.sellingOrders = sellingOrderService.GetAll();

            //Neu startDate && end Date != null thi xuat danh sach dua tren 2 ngay da nhap 
            if(revenue.startDate!=null && revenue.endDate!=null)
            {
            //   revenue.sellingOrders= _db.SellingOrders.Include(r => r.Customer).Include(r => r.Employee)
            //     .Where(p => (p.CreatedDate >= revenue.startDate && p.CreatedDate <= revenue.endDate) ;
                revenue.sellingOrders = sellingOrderService.GetStatistics((DateTime)revenue.startDate, (DateTime)revenue.endDate);

                ViewBag.Revenue = new RevenueStatistics()
                {
                    startDate=revenue.startDate,
                    endDate=revenue.endDate,
                    currentDate=null
                    
                };
            }
            else
             {
                ViewBag.Revenue = new RevenueStatistics()
                {
                    startDate=null,
                    currentDate=DateTime.Now,
                    endDate= null
                };
             }
            return View (revenue.sellingOrders);

            //var revenue =  _db.SellingOrders.Include(r => r.Customer).Include(r => r.Employee).AsQueryable();
            //return View(await revenue.ToListAsync());
         }

 

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(DateTime startDay, DateTime endDay)
        {
            var revenue = from o in _db.SellingOrders select o;
            revenue = revenue.Where(s => s.CreatedDate >= startDay && s.CreatedDate <= endDay);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", revenue.ToList()) });

        }*/
    }
}