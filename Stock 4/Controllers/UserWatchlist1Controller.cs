using Microsoft.AspNetCore.Mvc;
using Stock4.Models;
using Stock4.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Stock4.Controllers
{
    public class UserWatchlist1Controller : Controller
    {
        private IUserWatchlist1Repository _userWatchlist1Repository;
        //private UserManager<AuthorizedUser> _UserManager;
        //private IClientNotification _clientNotification;


        public UserWatchlist1Controller(IUserWatchlist1Repository userWatchlist1Repository /*,UserManager<AuthorizedUser> userManager,*/ /*IClientNotification clientNotification*/)
        {
            _userWatchlist1Repository = userWatchlist1Repository;
            //_UserManager = userManager;
            //_clientNotification = clientNotification;

        }

        public IActionResult Index()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            if (ViewBag.UserId != null)
            {
                var userId=ViewBag.Userid;

                var watchlists = _userWatchlist1Repository.GetUserWatchlist1(userId);

                return View(watchlists);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(int StockId)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            var userId = ViewBag.Userid;

            var Watchlist1 = new UserWatchlist1()
            {
                StockId = StockId,
                UserId = userId
            };
            _userWatchlist1Repository.Create(Watchlist1);
            //_clientNotification
            // .AddSweetNotification("Success", "the stock has been added to Watchlist 1", NotificationType.success);
            return RedirectToAction("Index");
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int Id)
        {
            var userWatchlist1 = _userWatchlist1Repository.GetUserWatchlist1s(Id);
            _userWatchlist1Repository.Remove(userWatchlist1);

            //_clientNotification
            //    .AddSweetNotification("Success", "the stock has been removed from Watchlist 1", NotificationType.success);

            return RedirectToAction(nameof(Index));
        }

    }
}
