using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult Index()
        {
            Session["token"] = null;
            return RedirectToAction("Index", "LogIn");
        }
    }
}