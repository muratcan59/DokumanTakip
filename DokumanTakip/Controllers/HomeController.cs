using DokumanTakip.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokumanTakip.Controllers
{
    public class HomeController : Controller
    {
        [AdminLoginFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}