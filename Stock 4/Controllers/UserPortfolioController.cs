using Microsoft.AspNetCore.Mvc;
using Stock_4.Models;
using Stock4.DataT;
using Stock4.Models;

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
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            if(ViewBag.UserId != 0 && ViewBag.UserId != null)
            {
                int userId = ViewBag.UserId;

                var uplist = (from od in _context.userPortfolios
                                join a in _context.stockLists
                                on od.Stock.StockId equals a.StockId where od.UserId == userId
                                select new UserPortfolio
                                {

                                    StockName=od.Stock.StockName,
                                    Qty=od.Qty,
                                    BoughtAt=od.BoughtAt,
                                    BoughtAtTotal=od.BoughtAtTotal,
                                    CurrentPrice = a.StockPrice,
                                    CurrentPriceTotal = a.StockPrice * od.Qty,
                                    ProfOrLoss=(a.StockPrice * od.Qty)-od.BoughtAtTotal
                                                  
                                }).ToList();
                return View(uplist);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuyStock(int StockId,int BuyQty,float StockPrice)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            var userId = ViewBag.Userid;

            AuthorizedUser AvFund =new AuthorizedUser();

            var PurchaseFund = StockPrice * BuyQty;

            foreach(var item in _context.authorizedUsers)
            {
                if (item.UserId == userId)
                {
                    AvFund.AvailableFund = item.AvailableFund;
                }
                continue; // get out of the loop
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
                            UserId = userId,
                            Qty = BuyQty,
                            BoughtAt = StockPrice,
                            BoughtAtTotal = StockPrice * BuyQty,
                            CurrentPrice = StockPrice,
                            CurrentPriceTotal = StockPrice * BuyQty
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
    }
}
