using MyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Controllers
{
    public class PhongTapController : Controller
    {
        private BLL mBll = new BLL();
        // GET: PhongTap
        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListPT = mBll.GetListPhongTap();
            ViewBag.mBll = mBll;
            return View();
        }

        public ActionResult Create()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult AddPT(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            try
            {
                mBll.AddPT(new PhongTap
                {
                    MaPhongTap = form["mapt"],
                    TenPhongTap = form["tenpt"]
                });
            }
            catch (Exception e) { }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string mapt)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.DeletePT(mBll.GetPTFromMaPT(mapt));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string mapt)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mPT = mBll.GetPTFromMaPT(mapt);
            return View();
        }

        public ActionResult EditPT(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.UpdatePT(form["mapt"], form["tenpt"]);
            return RedirectToAction("Index");
        }

        public ActionResult Search(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<PhongTap> mListHV = new List<PhongTap>();
            for (int i = 0; i < Int32.Parse(Session["PTsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetPTFromMaPT(Session["PT" + i.ToString()].ToString()));
            }
            ViewBag.mListPT = mBll.SearchPT(mListHV, form["search"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }

        public ActionResult Sort(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<PhongTap> mListHV = new List<PhongTap>();
            for (int i = 0; i < Int32.Parse(Session["PTsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetPTFromMaPT(Session["PT" + i.ToString()].ToString()));
            }
            ViewBag.mListPT = mBll.SortPT(mListHV, form["sort"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }
    }
}