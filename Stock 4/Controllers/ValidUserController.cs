using javax.swing.@event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock_4.Models;
using Stock4.DataT;
using Newtonsoft.Json;
using System.Net.Http;

namespace Stock4.Controllers
{
    
    public class ValidUserController : Controller
    {
        private readonly StockContext _context;

        public ValidUserController(StockContext context)
        {
            _context = context;
        }

        public IActionResult ValidUserHomePage()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            if (ViewBag.UserId != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
             
        
        public async Task<IActionResult> ValidUserIndex()
        {
            return View(await _context.stockLists.ToListAsync());
        }

        public async Task<IActionResult> VUStockDetails(int? id)
        {
            if (id == null || _context.stockLists == null)
            {
                return NotFound();
            }

            var stockList = await _context.stockLists
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stockList == null)
            {
                return NotFound();
            }

            return View(stockList);
        }

        



    }
}
