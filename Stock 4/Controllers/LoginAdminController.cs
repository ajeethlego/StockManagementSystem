using Microsoft.AspNetCore.Mvc;
using Stock4.DataT;
using Stock4.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Stock_4.Models;
using Microsoft.AspNetCore.Authorization;

namespace Stock_4.Controllers
{
    
    public class LoginAdminController : Controller
    {
        private readonly StockContext _db;
        public LoginAdminController(StockContext db)
        {
            _db = db;
        }
        public IActionResult AdminToLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminToLogin(AdminDetails adminDetails)
        {
            AdminDetails result = (from i in _db.adminDetails
                                     where i.AdminEmail == adminDetails.AdminEmail && i.AdminPassword == adminDetails.AdminPassword
                                     select i).FirstOrDefault();


            if (result == null)
            {
                ModelState.AddModelError("Error", "Email Id or Password is Wrong.");
                return View();
            }
            else
            {
                int AdminId = result.AdminId;
                HttpContext.Session.SetInt32("AdminId", AdminId);

                string AdminName = result.AdminName;
                HttpContext.Session.SetString("AdminName", AdminName);

                return RedirectToAction("AdminHomePage", "Admin");
            }

        }

        public IActionResult AdminToRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminToRegister([Bind("AdmminId,AdminName,AdminEmail,AdminPassword")] AdminDetails adminDetails)
        {
            //if (ModelState.IsValid)
            //{
            _db.Add(adminDetails);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(AdminToLogin));
            //}
            //return View(authorizedUser);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}
