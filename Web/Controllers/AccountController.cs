using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models.Account;
using WebMatrix.WebData;

namespace Web.Controllers
{
    /// <summary>
    /// Controller responsible for operating with user accounts.
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(model.Login, model.Password))
                {
                    if (returnUrl != null)
                        return Redirect(returnUrl);
                    return RedirectToAction("List", "Flight");
                }
                ModelState.AddModelError("", "Sorry, the username or password is invalid");
            }
            return View(model);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model, string role, string corpass)
        {
            if (ModelState.IsValid)
            {
                if (new string[] { "Admin", "Dispecher" }.Contains(role) && !corpass.ToLower().Equals("airplanner"))
                {
                    ModelState.AddModelError("", "Sorry, your corporate password is incorrect");
                    return View(model);
                }
                try
                {
                    WebSecurity.CreateUserAndAccount(model.Login, model.Password);
                    Roles.AddUserToRole(model.Login, role);
                    return RedirectToAction("List", "Flight");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Sorry, the username already exists");
                }
            }
            return View(model);
        }
        
        public ActionResult Logoff()
        {
            WebSecurity.Logout();
            return RedirectToAction("List", "Flight");
        }
    }
}