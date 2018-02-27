using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HippoCampus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator") ||
                User.IsInRole("Student Worker"))
            {
                return RedirectToAction("LoginView");
            } 

              
            return View();
        }

        [Authorize(Roles = "Administrator, Student Worker")]
        public ActionResult LoginView()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}