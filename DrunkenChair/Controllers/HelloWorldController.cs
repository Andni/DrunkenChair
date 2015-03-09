using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrunkenChair.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public ActionResult Welcome(string message, int numTimes = 1)
        {

            ViewBag.message = message;
            ViewBag.numTimes = numTimes;

            return View();
        }
    }
}