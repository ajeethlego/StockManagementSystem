using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stock_4.Models;
using Stock4.DataT;
using Stock4.Models;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;

namespace Stock_4.Controllers
{
    
    public class UserPortfolioController : Controller
    {
        private StockContext _context;
        public UserPortfolioController(StockContext context)
        {
            _context = context;
        }

        public IActionResult UserPortfolioIndex()
        {
           /* //for testing purpose
            ViewBag.UserId = 1;*/

            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            
            
            
            if(ViewBag.UserId != 0 && ViewBag.UserId != null)
            {
                int userId = ViewBag.UserId;

                var uplist = (from od in _context.userPortfolios
                                join a in _context.stockLists
                                on od.Stock.StockId equals a.StockId where od.UserId == userId
                                select new UserPortfolio
                                {
                                    Id= od.Id,
                                    StockId= od.StockId,
                                    StockName=od.Stock.StockName,
                                    Qty=od.Qty,
                                    BoughtAt=od.BoughtAt,
                                    BoughtAtTotal=od.BoughtAtTotal,
                                    CurrentPrice = a.StockPrice,
                                    CurrentPriceTotal = a.StockPrice * od.Qty,
                                    ProfOrLoss=(a.StockPrice - od.BoughtAt) *od.Qty
                                                  
                                }).ToList();
                return View(uplist);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuyStock(int StockId,int BuyQty,float StockPrice,string StockName)
        {
         /*   //for testing purpose
            ViewBag.UserId = 1;*/





            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            
            
            
            var userId = ViewBag.Userid;

            AuthorizedUser AvFund =new AuthorizedUser();

            var PurchaseFund = StockPrice * BuyQty;

            foreach(var item in _context.authorizedUsers)
            {
                if (item.UserId == userId)
                {
                    AvFund.AvailableFund = item.AvailableFund;
                    break;
                }
            }

            if (userId != null)
            {
                if (PurchaseFund<=AvFund.AvailableFund)
                {
                    AvFund.AvailableFund -= PurchaseFund;
                    var F = _context.authorizedUsers.FirstOrDefault(i => i.AvailableFund != AvFund.AvailableFund);
                    if (F != null)
                    {
                        F.AvailableFund=AvFund.AvailableFund;
                    }

                    var UpCell = _context.authorizedUsers.FirstOrDefault(i => i.AvailableFund != AvFund.AvailableFund);

                    foreach (var item in _context.authorizedUsers)
                    {
                        if (item.UserId == userId)
                        {
                            UpCell = F;
                            break; // get out of the loop
                        }
                    }
                    _context.Update(UpCell);
                    _context.SaveChanges();
                        
                    var port = new UserPortfolio
                    {
                      StockId = StockId,
                      StockName=StockName,
                      UserId = userId,
                      Qty = BuyQty,
                      BoughtAt = StockPrice,
                      BoughtAtTotal = StockPrice * BuyQty,
                      CurrentPrice = 0,
                      CurrentPriceTotal = 0
                    };
                    _context.userPortfolios.Add(port);
                    _context.SaveChanges();
                }
                else
                {
                    ViewBag.InsufficientFundError = "You have no sufficient Securities in Available Funds!!!";
                }
            }
            return RedirectToAction("UserPortfolioIndex");
        }
        public IActionResult AddStock(int StockId, int BuyQty, float StockPrice, string StockName)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            var userId = ViewBag.Userid;

            var port1 = _context.userPortfolios.FirstOrDefault(i=>i.StockId==StockId);
            foreach (var item in _context.userPortfolios)
            {
                if (item.UserId == userId && item.StockId == StockId)
                {

                    item.StockId = StockId;
                    item.StockName = StockName;
                    item.UserId = userId;
                    item.BoughtAtTotal = (((item.BoughtAt * item.Qty) + (StockPrice * BuyQty)) * (item.Qty + BuyQty)) / (item.Qty + BuyQty);
                    item.BoughtAt = ((item.BoughtAt * item.Qty) + (StockPrice * BuyQty)) / (item.Qty + BuyQty);
                    item.Qty = item.Qty + BuyQty;
                    item.CurrentPrice = 0;
                    item.CurrentPriceTotal = 0;
                    item.ProfOrLoss = 0;
                }
                port1 = item;
                continue;
            }
            _context.userPortfolios.Update(port1);
            _context.SaveChanges();
            return RedirectToAction("UserPortfolioIndex");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SellAllStock(int Id,float CurrentPrice )
        {
           /*    //for testing purpose
            ViewBag.UserId = 1;*/


            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            
            
            var userId = ViewBag.Userid;

            AuthorizedUser AvFund = new AuthorizedUser();
            float SoldFund = 0;
            foreach (var item in _context.userPortfolios)
            {
                if (item.Id == Id)
                {
                    SoldFund = CurrentPrice * item.Qty;
                    break;
                }
            }

            foreach (var item in _context.authorizedUsers)
            {
                if (item.UserId == userId)
                {
                    AvFund.AvailableFund = item.AvailableFund;
                    break;
                  // get out of the loop
                }
            }

            if (userId != null)
            {
                AvFund.AvailableFund += SoldFund;
                var F = _context.authorizedUsers.FirstOrDefault(i => i.AvailableFund != AvFund.AvailableFund);
                if (F != null)
                {
                    F.AvailableFund = AvFund.AvailableFund;
                }

                var UpCell = _context.authorizedUsers.FirstOrDefault(i => i.AvailableFund != AvFund.AvailableFund);

                foreach (var item in _context.authorizedUsers)
                {
                    if (item.UserId == userId)
                    {
                        UpCell = F;
                        break; // get out of the loop
                    }   
                }
                _context.Update(UpCell);
                _context.SaveChanges();
            }
            
            foreach(var item in _context.userPortfolios)
            {
                if (item.Id == Id)
                {
                    _context.userPortfolios.Remove(item);
                    
                    break;
                }
            }
            _context.SaveChanges();

            return RedirectToAction("UserPortfolioIndex");
        }
    }
}
