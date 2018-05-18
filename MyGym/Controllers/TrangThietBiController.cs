using MyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Controllers
{
    public class TrangThietBiController : Controller
    {
        private BLL mBll = new BLL();
        // GET: TrangThietBi
        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListTTB = mBll.GetListTrangThietBi();
            ViewBag.mBll = mBll;
            return View();
        }

        public ActionResult Create()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListPT = mBll.GetListPhongTap();
            return View();
        }

        public ActionResult AddTTB(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            try
            {
                mBll.AddTTB(new TrangThietBi
                {
                    MaThietBi = form["matb"],
                    TenThietBi = form["tentb"],
                    TinhTrangSuDung = (Request.Form["tinhtrangsudung"].ToString().Equals("true")) ? true : false,
                    MaPhongTap = form["mapt"],
                });
            }
            catch (Exception e)
            {

            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string matb)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.DeleteTTB(mBll.GetTTBFromMaTTB(matb));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string matb)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mTb = mBll.GetTTBFromMaTTB(matb);
            ViewBag.mListPT = mBll.GetListPhongTap();
            return View();
        }

        public ActionResult EditTTB(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.UpdateTTB(form["matb"], form["tentb"], (Request.Form["tinhtrangsudung"].ToString() == "true") ? true : false, form["mapt"]);
            return RedirectToAction("Index");
        }

        public ActionResult Search(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<TrangThietBi> mListHV = new List<TrangThietBi>();
            for (int i = 0; i < Int32.Parse(Session["TTBsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetTTBFromMaTTB(Session["TTB" + i.ToString()].ToString()));
            }
            ViewBag.mListTTB = mBll.SearchTBB(mListHV, form["search"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }

        public ActionResult SearchFromPT(string mapt)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListTTB = mBll.SearchTBB(mBll.GetListTrangThietBi(), mapt);
            ViewBag.mBll = mBll;
            return View("Index");
        }

        public ActionResult Sort(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<TrangThietBi> mListHV = new List<TrangThietBi>();
            for (int i = 0; i < Int32.Parse(Session["TTBsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetTTBFromMaTTB(Session["TTB" + i.ToString()].ToString()));
            }
            ViewBag.mListTTB = mBll.SortTTB(mListHV, form["sort"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }
    }
}