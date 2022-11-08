using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock4.DataT;
using Stock4.Models;
using System.Linq;

namespace Stock4.Controllers
{
    public class AdminController : Controller
    {
        private readonly StockContext _context;

        public AdminController(StockContext context)
        {
            _context = context;
        }

        public IActionResult AdminHomePage()
        {
            return View();
        }

        public async Task<IActionResult> ViewCustomers()
        {
            return View(await _context.authorizedUsers.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> ViewCustomers(string Usersearch)
        {
            ViewData["GetUserData"]=Usersearch;
            var Userquery=from x in _context.authorizedUsers select x;
            if (!String.IsNullOrEmpty(Usersearch))
            {
                Userquery = Userquery.Where(x => x.UserName.Contains(Usersearch)
                || x.EmailId.Contains(Usersearch)
                || x.CityName.Contains(Usersearch)
                || x.PanNumber.Contains(Usersearch));
            }
            return View(await Userquery.AsNoTracking().ToListAsync());
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.stockLists.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockId,StockName,StockPrice")] StockList stockList)
        {
            if (ModelState.Count!=0)
            {
                _context.Add(stockList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(stockList);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.stockLists == null)
            {
                return NotFound();
            }

            var stockList = await _context.stockLists.FindAsync(id);
            if (stockList == null)
            {
                return NotFound();
            }
            return View(stockList);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,StockName,StockPrice")] StockList stockList)
        {
            if (id != stockList.StockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockListExists(stockList.StockId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stockList);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.stockLists == null)
            {
                return Problem("Entity set 'StockContext.stockLists'  is null.");
            }
            var stockList = await _context.stockLists.FindAsync(id);
            if (stockList != null)
            {
                _context.stockLists.Remove(stockList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockListExists(int id)
        {
            return _context.stockLists.Any(e => e.StockId == id);
        }


    }
}
