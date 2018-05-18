using MyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Controllers
{
    public class TaiKhoanController : Controller
    {
        private BLL mBll = new BLL();
        // GET: TaiKhoan
        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListTK = mBll.GetListTaiKhoan();
            ViewBag.mBll = mBll;
            return View();
        }

        public ActionResult Delete(string tendn)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.DeleteTK(mBll.GetTKFromTenDangNhap(tendn));
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult AddTK(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
                try
                {
                    mBll.AddTK(new TaiKhoan
                    {
                        TenDangNhap = form["tendn"],
                        MatKhau = Common.GetMD5(form["mk"]),
                        permission = form["permission"],
                        token = "",
                        ThoiGianLogIn = DateTime.Now
                    });
                }
                catch (Exception e)
                {

                }
                return RedirectToAction("Index");
        }

        public ActionResult Search(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<TaiKhoan> mListHV = new List<TaiKhoan>();
            for (int i = 0; i < Int32.Parse(Session["TKsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetTKFromTenDangNhap(Session["TK" + i.ToString()].ToString()));
            }
            ViewBag.mListTK = mBll.SearchTK(mListHV, form["search"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }
    }
}