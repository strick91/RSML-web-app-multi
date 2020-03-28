using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSML_web_app.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unresolved()
        {
            return RedirectToAction("Index", "Unresolveds");
        }

        public ActionResult Resolved()
        {
            return RedirectToAction("Index", "Resolveds");
        }

        public ActionResult ConfirmedDevices()
        {
            return RedirectToAction("Index", "ConfirmedDevices");
        }

        public ActionResult ConfirmedDevicesInStore()
        {
            return RedirectToAction("Index", "ConfirmedDevicesInStores");
        }

        public ActionResult ValidStores()
        {
            return RedirectToAction("Index", "ValidStores");
        }

        public ActionResult SignOut()
        {
            var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/");
            return View();
        }

        public ActionResult SignIn()
        {
            Response.Redirect("/Login.aspx");
            return View();
        }
    }
}