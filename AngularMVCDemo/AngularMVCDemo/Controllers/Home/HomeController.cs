using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMVCDemo.Controllers.Home
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("LogIn");
        }

        public ActionResult LogIn()
        {

        }
	}
}