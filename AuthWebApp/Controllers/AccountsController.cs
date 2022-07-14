using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AuthWebApp.Models;

namespace AuthWebApp.Controllers
{
    public class AccountsController : Controller
    {
        AuthdbEntities entity = new AuthdbEntities();
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExists = entity.Users.Any(x => x.Email == credentials.Email && x.Passcode == credentials.Password);
            User u = entity.Users.FirstOrDefault(x => x.Email == credentials.Email && x.Passcode == credentials.Password);
            if (userExists)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Username or Password does not match");
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User userinfo)
        {
            entity.Users.Add(userinfo);
            entity.SaveChangesAsync();
            return RedirectToAction("Login");
            
        }
        public ActionResult Singout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}