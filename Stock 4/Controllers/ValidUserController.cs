using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock4.DataT;

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
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            int userid =ViewBag.UserId;
            ViewBag.WatchlistBtn = null;

            foreach (var item in _context.UserWatchlist1)
            {
                if(item.UserId== userid && item.StockId == id)
                {
                    int WatchlistBtn = item.UserId;
                    HttpContext.Session.SetInt32("WatchlistBtn", WatchlistBtn);
                    ViewBag.WatchlistBtn = HttpContext.Session.GetInt32("WatchlistBtn");
                }
            }

            foreach (var item in _context.userPortfolios)
            {
                if (item.UserId == userid && item.StockId == id)
                {
                    int portBtn = item.UserId;
                    HttpContext.Session.SetInt32("portBtn", portBtn);
                    ViewBag.portBtn = HttpContext.Session.GetInt32("portBtn");
                }
            }


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
