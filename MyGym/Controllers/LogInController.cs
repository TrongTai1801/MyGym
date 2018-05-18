using MyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Controllers
{
    public class LogInController : Controller
    {
        private BLL mBll = new BLL();
        // GET: LogIn
        public ActionResult Index()
        {
            Session["Login"] = 2;
            return View();
        }

        public ActionResult CheckLogin(FormCollection form)
        {
            string check = mBll.checkLogin(form["tenDangNhap"], form["matKhau"]);
            if (check != "")
            {
                if (mBll.GetTKFromTenDangNhap(form["tenDangNhap"]).permission.Equals("1")) Session["Login"] = 1;
                else Session["Login"] = 2;
                Session["token"] = check;
                if (Session["Login"].ToString().Equals("1")) {
                    return RedirectToAction("Index", "HoiVien");
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }
    }
}