using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaGit.Web.Controllers
{
    public class homeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bienvenido()
        {
            return View();
        }
    }
}