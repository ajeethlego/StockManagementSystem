using java.lang;
using jdk.@internal.org.objectweb.asm.tree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock4.DataT;

namespace Stock_4.Controllers
{
    public class FundController : Controller
    {
        private StockContext _context;
        public FundController(StockContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> FundIndex()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            if(ViewBag.UserId !=null)
            {
               return View(await _context.authorizedUsers.ToListAsync());
            }
            else
            {
                return View("Error"); 
            }

            

        }

        //[HttpPost]
        //public IActionResult ToAddFunds(float amount)
        //{
        //    var balance = 
        //}


    }
}
