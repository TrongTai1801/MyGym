using MyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Controllers
{
    public class NhanVienController : Controller
    {
        private BLL mBll = new BLL();
        // GET: NhanVien
        public ActionResult Index()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mBll = mBll;
            ViewBag.mListNV = mBll.GetListNhanVien();
            return View();
        }

        public ActionResult Create()
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListCV = mBll.GetListChucVu();
            return View();
        }

        public ActionResult AddNV(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            double hsl;
            int mobile;
            int cmnd;
            if (!Int32.TryParse(form["sdt"], out mobile) && !Int32.TryParse(form["cmnd"], out cmnd) && !Double.TryParse(form["hsl"], out hsl))
            {
                return RedirectToAction("Create");
            }
            else
            {
                try
                {
                    mBll.AddNV(new NhanVien
                    {
                        Ma = form["mahv"],
                        Ten = form["tenhv"],
                        CMND = form["cmnd"],
                        NgaySinh = Convert.ToDateTime(form["ngaysinh"]),
                        GioiTinh = (Request.Form["gioitinh"].ToString().Equals("male")) ? true : false,
                        DiaChi = form["diachi"],
                        SDT = form["sdt"],
                        MaChucVu = form["machucvu"],
                        HeSoLuong = Convert.ToDouble(form["hsl"])
                    });
                }
                catch (Exception e)
                {

                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string manv)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            mBll.DeleteNV(mBll.GetNVFromMaNV(manv));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string manv)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.mListCV = mBll.GetListChucVu();
            ViewBag.mNV = mBll.GetNVFromMaNV(manv);
            return View();
        }

        public ActionResult EditNV(FormCollection form)
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
                mBll.UpdateNV(form["mahv"], form["tenhv"], form["cmnd"], Convert.ToDateTime(form["ngaysinh"]),
                    (Request.Form["gioitinh"].ToString() == "male") ? true : false,
                    form["diachi"], form["sdt"], form["machucvu"], Convert.ToDouble(form["hsl"]));
                return RedirectToAction("Index");

            }
        }

        public ActionResult Search(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<NhanVien> mListHV = new List<NhanVien>();
            for (int i = 0; i < Int32.Parse(Session["NVsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetNVFromMaNV(Session["NV" + i.ToString()].ToString()));
            }
            ViewBag.mListNV = mBll.SearchNV(mListHV, form["search"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }

        public ActionResult Sort(FormCollection form)
        {
            if (Session["token"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<NhanVien> mListHV = new List<NhanVien>();
            for (int i = 0; i < Int32.Parse(Session["NVsize"].ToString()); i++)
            {
                mListHV.Add(mBll.GetNVFromMaNV(Session["NV" + i.ToString()].ToString()));
            }
            ViewBag.mListNV = mBll.SortNV(mListHV, form["sort"]);
            ViewBag.mBll = mBll;
            return View("Index");
        }
    }
}