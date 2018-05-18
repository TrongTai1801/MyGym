using MyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Controllers
{
    public class ChucVuController : Controller
    {
        private BLL mBll = new BLL();
        // GET: ChucVu
        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListCV = mBll.GetListChucVu();
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

        public ActionResult AddCV(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            double hscv;
            if (!Double.TryParse(form["hscv"], out hscv))
            {
                return RedirectToAction("Create");
            }
            else
            {
                try
                {
                    mBll.AddCV(new ChucVu
                    {
                        MaChucVu = form["macv"],
                        TenChucVu = form["tencv"],
                        HeSoChucVu = Convert.ToDouble(form["hscv"])
                    });
                }
                catch (Exception e)
                {

                }

                return RedirectToAction("Create","NhanVien");
            }
        }

        public ActionResult Delete(string macv)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.DeleteCV(mBll.GetChucVuFromMaChucVu(macv));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string macv)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mCv = mBll.GetChucVuFromMaChucVu(macv);
            return View();
        }

        public ActionResult EditCV(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.UpdateCV(form["macv"], form["tencv"], Convert.ToDouble(form["hscv"]));
            return RedirectToAction("Index");
        }

        public ActionResult Search(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<ChucVu> mListHV = new List<ChucVu>();
            for (int i = 0; i < Int32.Parse(Session["CVsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetChucVuFromMaChucVu(Session["CV" + i.ToString()].ToString()));
            }
            ViewBag.mListCV = mBll.SearchCV(mListHV, form["search"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }

        public ActionResult Sort(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<ChucVu> mListHV = new List<ChucVu>();
            for (int i = 0; i < Int32.Parse(Session["CVsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetChucVuFromMaChucVu(Session["CV" + i.ToString()].ToString()));
            }
            ViewBag.mListCV = mBll.SortCV(mListHV, form["sort"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }
    }
}