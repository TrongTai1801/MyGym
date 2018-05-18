using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyGym.Models;

namespace MyGym.Controllers
{
    public class HoiVienController : Controller
    {
        private BLL mBll = new BLL();
        // GET: HoiVien
        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mBll = mBll;
            ViewBag.mListHV = mBll.GetListHoiVien();
            return View();
        }

        public ActionResult Create()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListGT = mBll.GetListGoiTap();
            return View();
        }

        public ActionResult AddHV(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int mobile;
            int cmnd;
            if (!Int32.TryParse(form["sdt"], out mobile) && !Int32.TryParse(form["cmnd"], out cmnd))
            {
                return RedirectToAction("Create");
            }
            else
            {
                try
                {
                    mBll.AddHV(new HoiVien
                    {
                        Ma = form["mahv"],
                        Ten = form["tenhv"],
                        CMND = form["cmnd"],
                        NgaySinh = Convert.ToDateTime(form["ngaysinh"]),
                        GioiTinh = (Request.Form["gioitinh"].ToString().Equals("male")) ? true : false,
                        DiaChi = form["diachi"],
                        SDT = form["sdt"],
                        MaGoi = form["magoi"]
                    });
                }
                catch (Exception e)
                {

                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string mahv)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.DeleteHV(mBll.GetHVFromMaHV(mahv));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string mahv)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mHV = mBll.GetHVFromMaHV(mahv);
            ViewBag.mListGT = mBll.GetListGoiTap();
            return View();
        }

        public ActionResult EditHV(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int mobile;
            int cmnd;
            if (!Int32.TryParse(form["sdt"], out mobile) && !Int32.TryParse(form["cmnd"], out cmnd))
            {
                return RedirectToAction("index");
            }
            else
            {
                mBll.UpdateHV(form["mahv"], form["tenhv"], form["cmnd"], Convert.ToDateTime(form["ngaysinh"]),
                    (Request.Form["gioitinh"].ToString() == "male") ? true : false,
                    form["diachi"], form["sdt"], form["magoi"]);
                return RedirectToAction("Index");

            }
        }

        public ActionResult Search(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<HoiVien> mListHV = new List<HoiVien>();
            for (int i = 0; i < Int32.Parse(Session["HVsize"].ToString()); i++) {
                mListHV.Add(mBll.GetHVFromMaHV(Session["HV"+i.ToString()].ToString()));
            }
            ViewBag.mListHV = mBll.SearchHV(mListHV, form["search"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }

        public ActionResult SearchFromGT(string magoi)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListHV = mBll.SearchHV(mBll.GetListHoiVien(), magoi);
            ViewBag.mBll = mBll;
            return View("Index");
        }

        public ActionResult Sort(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<HoiVien> mListHV = new List<HoiVien>();
            for (int i = 0; i < Int32.Parse(Session["HVsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetHVFromMaHV(Session["HV" + i.ToString()].ToString()));
            }
            ViewBag.mListHV = mBll.SortHV(mListHV, form["sort"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }
    }
}