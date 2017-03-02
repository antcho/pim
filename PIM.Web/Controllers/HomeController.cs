using PIM.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIM.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PIMContext context = new PIMContext();
            
            
            return View();
        }
    }
}