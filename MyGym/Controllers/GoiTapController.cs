using MyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Controllers
{
    public class GoiTapController : Controller
    {
        private BLL mBll = new BLL();
        // GET: GoiTap
        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListGT = mBll.GetListGoiTap();
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

        public ActionResult AddGT(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int giathanh;
            if (!Int32.TryParse(form["giathanh"], out giathanh))
            {
                return RedirectToAction("Create");
            }
            else
            {
                try
                {
                    mBll.AddGT(new GoiTap
                    {
                        MaGoi = form["magt"],
                        TenGoi = form["tengt"],
                        GiaThanh = Convert.ToInt32(form["giathanh"])
                    });
                }
                catch (Exception e)
                {

                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string magoi)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.DeleteGT(mBll.GetGoiTapFromMaGoi(magoi));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string magt)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mGT = mBll.GetGoiTapFromMaGoi(magt);
            return View();
        }

        public ActionResult EditGT(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.UpdateGT(form["magt"], form["tengt"], Convert.ToDouble(form["giathanh"]));
                return RedirectToAction("Index");
        }

        public ActionResult Search(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<GoiTap> mListHV = new List<GoiTap>();
            for (int i = 0; i < Int32.Parse(Session["GTsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetGoiTapFromMaGoi(Session["GT" + i.ToString()].ToString()));
            }
            ViewBag.mListGT = mBll.SearchGT(mListHV, form["search"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }

        public ActionResult Sort(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<GoiTap> mListHV = new List<GoiTap>();
            for (int i = 0; i < Int32.Parse(Session["GTsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetGoiTapFromMaGoi(Session["GT" + i.ToString()].ToString()));
            }
            ViewBag.mListGT = mBll.SortGT(mListHV, form["sort"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }
    }
}