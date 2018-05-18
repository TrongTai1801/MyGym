using MyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Controllers
{
    public class HomeController : Controller
    {
        private BLL mBll = new BLL();

        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult About()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Message = "Your application description page.";
            ViewBag.mListHV = mBll.GetListHoiVien();
            return View();
        }

        public ActionResult Contact()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}