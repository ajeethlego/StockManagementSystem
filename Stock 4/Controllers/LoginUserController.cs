using Microsoft.AspNetCore.Mvc;
using Stock4.DataT;
using Stock4.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Stock_4.Controllers
{
    public class LoginUserController : Controller
    {
        private readonly StockContext _db;
        public LoginUserController(StockContext db)
        {
            _db = db;
        }
        public IActionResult UserToLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserToLogin(AuthorizedUser authorizedUser)
        {
            AuthorizedUser result = (from i in _db.authorizedUsers
                                     where i.EmailId == authorizedUser.EmailId && i.Password==authorizedUser.Password
                                     select i).FirstOrDefault();

            
            if (result == null)
            {
                ModelState.AddModelError("Error","Email Id or Password is Wrong.");
                return View();
            }
            else
            {
                int UserId = result.UserId;
                HttpContext.Session.SetInt32("UserId", UserId);

                string UserName = result.UserName;
                HttpContext.Session.SetString("UserName", UserName);

                return RedirectToAction("ValidUserHomePage", "ValidUser");
            }
            
        }

        public IActionResult UserToRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserToRegister([Bind("UserId,UserName,DateOfBirth,PanNumber,IncomePerAnum,EmploymentType,CityName,Pincode,EmailId,Password")] AuthorizedUser authorizedUser)
        {
            //if (ModelState.IsValid)
            //{
            _db.Add(authorizedUser);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(UserToLogin));
            //}
            //return View(authorizedUser);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
