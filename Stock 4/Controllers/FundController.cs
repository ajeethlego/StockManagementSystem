using com.sun.xml.@internal.bind.v2.model.core;
using java.lang;
using java.rmi.server;
using javax.swing;
using jdk.@internal.org.objectweb.asm.tree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock4.DataT;
using Stock4.Models;

namespace Stock_4.Controllers
{
    public class FundController : Controller
    {
        private StockContext _context;
        public FundController(StockContext context)
        {
            _context = context;
        }

            
        public async Task<IActionResult> FundIndex(int Id)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
           
            if (ViewBag.UserId == null || _context.authorizedUsers == null)
            {
                return NotFound();
            }
            var Af = await _context.authorizedUsers
                .FirstOrDefaultAsync(m => m.UserId == Id);
            if (Af == null)
            {
                return NotFound();
            }

            return View(Af);
        }
    

        [HttpPost]
        public IActionResult ToAddFunds(float amount, float AvailableFund)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            int Uid = ViewBag.UserId;
            if(Uid == 0)
            {
                return NotFound();
            }
            var F = _context.authorizedUsers.FirstOrDefault(i => i.AvailableFund == AvailableFund);
            if (F == null)
            {
                return NotFound();
            }
            F.AvailableFund = F.AvailableFund + amount;

            var UpCell=_context.authorizedUsers.FirstOrDefault(i => i.AvailableFund == AvailableFund);

            foreach (var item in _context.authorizedUsers)
            {
                if(item.UserId == Uid)
                {
                    UpCell = F;
                    break; // get out of the loop
                } 
            }
            _context.Update(UpCell);
            _context.SaveChanges();

            return RedirectToAction("ValidUserHomePage","ValidUser");
        }

        [HttpPost]
        public IActionResult ToRemoveFunds(float amount, float AvailableFund)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            int Uid = ViewBag.UserId;
            if (Uid == 0)
            {
                return NotFound();
            }
            var F = _context.authorizedUsers.FirstOrDefault(i => i.AvailableFund == AvailableFund);
            if (F == null)
            {
                return NotFound();
            }

            if (amount < AvailableFund)
            {
                F.AvailableFund = F.AvailableFund - amount;
                var UpCell = _context.authorizedUsers.FirstOrDefault(i => i.AvailableFund == AvailableFund);

                foreach (var item in _context.authorizedUsers)
                {
                    if (item.UserId == Uid)
                    {
                        UpCell = F;
                    }
                    break; // get out of the loop

                }
                _context.Update(UpCell);
                _context.SaveChanges();
            }
            else
            {
                ViewBag.RemoveFundError = "Please enter an amount that is less than or equal to that you own...";
            }

            return RedirectToAction("ValidUserHomePage", "ValidUser");
        }


    }
}
