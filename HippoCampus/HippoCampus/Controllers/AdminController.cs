using HippoCampus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HippoCampus.Controllers
{
    public class AdminController : Controller
    {
        //This statement is how we connect to our database content through this controller. 

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }



    }
}