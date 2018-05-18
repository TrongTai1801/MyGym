using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGym.Models
{
    public class BLL
    {
        private QuanLiGym mQuanLiGym;
        public delegate bool CompareObject(object o1, object o2);

        public BLL() {
            this.mQuanLiGym = new QuanLiGym();
        }

        public static void GenericSort(object[] list, CompareObject cmp)
        {
            for (int i = 0; i < list.Length - 1; i++)
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (cmp(list[i], list[j]))
                    {
                        object temp;
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
        }

        public List<HoiVien> GetListHoiVien()
        {
            return mQuanLiGym.HoiViens.ToList();
        }

        public List<GoiTap> GetListGoiTap() {
            return mQuanLiGym.GoiTaps.ToList();
        }

        public List<NhanVien> GetListNhanVien()
        {
            return mQuanLiGym.NhanViens.ToList();
        }

        public List<PhongTap> GetListPhongTap() {
            return mQuanLiGym.PhongTaps.ToList();
        }

        public List<TrangThietBi> GetListTrangThietBi() {
            return mQuanLiGym.TrangThietBis.ToList();
        }

        public List<ChucVu> GetListChucVu() {
            return mQuanLiGym.ChucVus.ToList();
        }

        public List<TaiKhoan> GetListTaiKhoan()
        {
            return mQuanLiGym.TaiKhoans.ToList();
        }

        public void AddHV(HoiVien hv)
        {
            mQuanLiGym.HoiViens.Add(hv);
            mQuanLiGym.SaveChanges();
        }

        public void AddNV(NhanVien nv)
        {
            mQuanLiGym.NhanViens.Add(nv);
            mQuanLiGym.SaveChanges();
        }

        public void AddGT(GoiTap gt)
        {
            mQuanLiGym.GoiTaps.Add(gt);
            mQuanLiGym.SaveChanges();
        }

        public void AddPT(PhongTap pt)
        {
            mQuanLiGym.PhongTaps.Add(pt);
            mQuanLiGym.SaveChanges();
        }

        public void AddTTB(TrangThietBi ttb)
        {
            mQuanLiGym.TrangThietBis.Add(ttb);
            mQuanLiGym.SaveChanges();
        }

        public void AddCV(ChucVu cv)
        {
            mQuanLiGym.ChucVus.Add(cv);
            mQuanLiGym.SaveChanges();
        }

        public void AddTK(TaiKhoan cv)
        {
            mQuanLiGym.TaiKhoans.Add(cv);
            mQuanLiGym.SaveChanges();
        }

        public void DeleteHV(HoiVien hv)
        {
            mQuanLiGym.HoiViens.Remove(hv);
            mQuanLiGym.SaveChanges();
        }

        public void DeleteNV(NhanVien nv)
        {
            mQuanLiGym.NhanViens.Remove(nv);
            mQuanLiGym.SaveChanges();
        }

        public void DeleteGT(GoiTap gt)
        {
            List<HoiVien> listHV = GetListHoiVien();
            foreach (HoiVien hv in listHV)
            {
                if (hv.MaGoi.Equals(gt.MaGoi))
                {
                    DeleteHV(hv);
                }
            }
            mQuanLiGym.GoiTaps.Remove(gt);
            mQuanLiGym.SaveChanges();
        }

        public void DeletePT(PhongTap pt)
        {
            List<TrangThietBi> mListTTB = GetListTrangThietBi();
            foreach (TrangThietBi ttb in mListTTB)
            {
                if (ttb.MaPhongTap.Equals(pt.MaPhongTap))
                {
                    DeleteTTB(ttb);
                }
            }
            mQuanLiGym.PhongTaps.Remove(pt);
            mQuanLiGym.SaveChanges();
        }

        public void DeleteTTB(TrangThietBi ttb)
        {
            mQuanLiGym.TrangThietBis.Remove(ttb);
            mQuanLiGym.SaveChanges();
        }

        public void DeleteCV(ChucVu cv)
        {
            List<NhanVien> listNV = GetListNhanVien();
            foreach (NhanVien nv in listNV)
            {
                if (nv.MaChucVu.Equals(cv.MaChucVu))
                {
                    DeleteNV(nv);
                }
            }
            mQuanLiGym.ChucVus.Remove(cv);
            mQuanLiGym.SaveChanges();
        }

        public void DeleteTK(TaiKhoan tk)
        {
            mQuanLiGym.TaiKhoans.Remove(tk);
            mQuanLiGym.SaveChanges();
        }

        public void UpdateHV(string mahv, string name, string cmnd, DateTime birthDay,
            bool gender, string address, string mobile, string magoi)
        {
            try
            {

                HoiVien hv1 = GetHVFromMaHV(mahv);
                hv1.Ma = mahv;
                hv1.Ten = name;
                hv1.NgaySinh = birthDay;
                hv1.GioiTinh = gender;
                hv1.DiaChi = address;
                hv1.SDT = mobile;
                hv1.MaGoi = magoi;
                hv1.CMND = cmnd;

                mQuanLiGym.SaveChanges();
            }
            catch (Exception e) { }

        }

        public void UpdateNV(string mahv, string name, string cmnd, DateTime birthDay,
           bool gender, string address, string mobile, string macv, double hsl)
        {
            try
            {

                NhanVien hv1 = GetNVFromMaNV(mahv);
                hv1.Ma = mahv;
                hv1.Ten = name;
                hv1.NgaySinh = birthDay;
                hv1.GioiTinh = gender;
                hv1.DiaChi = address;
                hv1.SDT = mobile;
                hv1.MaChucVu = macv;
                hv1.CMND = cmnd;
                hv1.HeSoLuong = hsl;
                mQuanLiGym.SaveChanges();
            }
            catch (Exception e) { }

        }

        public void UpdateGT(string magt, string name, double giathanh)
        {
            try
            {

                GoiTap hv1 = GetGoiTapFromMaGoi(magt);
                hv1.MaGoi = magt;
                hv1.TenGoi = name;
                hv1.GiaThanh = giathanh;

                mQuanLiGym.SaveChanges();
            }
            catch (Exception e) { }

        }

        public void UpdatePT(string mapt, string name)
        {
            try
            {

                PhongTap hv1 = GetPTFromMaPT(mapt);
                hv1.MaPhongTap = mapt;
                hv1.TenPhongTap = name;

                mQuanLiGym.SaveChanges();
            }
            catch (Exception e) { }

        }

        public void UpdateTTB(string magt, string name, bool tinhtrang, string mapt)
        {
            try
            {

                TrangThietBi hv1 = GetTTBFromMaTTB(magt);
                hv1.MaThietBi = magt;
                hv1.TenThietBi = name;
                hv1.MaPhongTap = mapt;
                hv1.TinhTrangSuDung = tinhtrang;

                mQuanLiGym.SaveChanges();
            }
            catch (Exception e) { }

        }

        public void UpdateCV(string magt, string name, double hsl)
        {
            try
            {

                ChucVu hv1 = GetChucVuFromMaChucVu(magt);
                hv1.MaChucVu = magt;
                hv1.TenChucVu = name;
                hv1.HeSoChucVu = hsl;
                mQuanLiGym.SaveChanges();
            }
            catch (Exception e) { }

        }

        public GoiTap GetGoiTapFromMaGoi(string magoi)
        {
            return mQuanLiGym.GoiTaps.Find(magoi);
        }

        public string GetTenGoiFromMaGoi(string magoi)
        {
            return mQuanLiGym.GoiTaps.Find(magoi).TenGoi.ToString();
        }

        public string GetTenPhongTapFromMaPhongTap(string maphongtap)
        {
            return mQuanLiGym.PhongTaps.Find(maphongtap).TenPhongTap.ToString();
        }

        public HoiVien GetHVFromMaHV(string mahv)
        {
            return mQuanLiGym.HoiViens.Find(mahv);
        }

        public NhanVien GetNVFromMaNV(string manv)
        {
            return mQuanLiGym.NhanViens.Find(manv);
        }

        public ChucVu GetChucVuFromMaChucVu(string macv)
        {
            return mQuanLiGym.ChucVus.Find(macv);
        }

        public PhongTap GetPTFromMaPT(string mapt)
        {
            return mQuanLiGym.PhongTaps.Find(mapt);
        }

        public TaiKhoan GetTKFromTenDangNhap(string tendangnhap) {
            return mQuanLiGym.TaiKhoans.Find(tendangnhap);
        }

        public TrangThietBi GetTTBFromMaTTB(string matb)
        {
            return mQuanLiGym.TrangThietBis.Find(matb);
        }

        public List<HoiVien> SearchHV(List<HoiVien> list, string key) {
            List<HoiVien> mListHV = new List<HoiVien>();
            {
                foreach (HoiVien hv2 in list)
                {
                    if (hv2.toStringHoiVien().Contains(key))
                        mListHV.Add(hv2);
                }
            }
            if (!mListHV.Any()) return null;
            return mListHV;
        }

        public List<NhanVien> SearchNV(List<NhanVien> list, string key)
        {
            List<NhanVien> mListHV = new List<NhanVien>();
            {
                foreach (NhanVien hv2 in list)
                {
                    if (hv2.toStringNhanVien().Contains(key))
                        mListHV.Add(hv2);
                }
            }
            if (!mListHV.Any()) return null;
            return mListHV;
        }

        public List<GoiTap> SearchGT(List<GoiTap> list, string key)
        {
            List<GoiTap> mListHV = new List<GoiTap>();
            {
                foreach (GoiTap hv2 in list)
                {
                    if (hv2.toStringGoiTap().Contains(key))
                        mListHV.Add(hv2);
                }
            }
            if (!mListHV.Any()) return null;
            return mListHV;
        }

        public List<PhongTap> SearchPT(List<PhongTap> list, string key)
        {
            List<PhongTap> mListHV = new List<PhongTap>();
            {
                foreach (PhongTap hv2 in list)
                {
                    if (hv2.toStringPhongTap().Contains(key))
                        mListHV.Add(hv2);
                }
            }
            if (!mListHV.Any()) return null;
            return mListHV;
        }

        public List<TrangThietBi> SearchTBB(List<TrangThietBi> list, string key)
        {
            List<TrangThietBi> mListHV = new List<TrangThietBi>();
            {
                foreach (TrangThietBi hv2 in list)
                {
                    if (hv2.toStringTrangThietBi().Contains(key))
                        mListHV.Add(hv2);
                }
            }
            if (!mListHV.Any()) return null;
            return mListHV;
        }

        public List<ChucVu> SearchCV(List<ChucVu> list, string key)
        {
            List<ChucVu> mListHV = new List<ChucVu>();
            {
                foreach (ChucVu hv2 in list)
                {
                    if (hv2.toStringChucVu().Contains(key))
                        mListHV.Add(hv2);
                }
            }
            if (!mListHV.Any()) return null;
            return mListHV;
        }

        public List<TaiKhoan> SearchTK(List<TaiKhoan> list, string key)
        {
            List<TaiKhoan> mListHV = new List<TaiKhoan>();
            {
                foreach (TaiKhoan hv2 in list)
                {
                    if (hv2.toStringTaiKhoan().Contains(key))
                        mListHV.Add(hv2);
                }
            }
            if (!mListHV.Any()) return null;
            return mListHV;
        }

        public List<HoiVien> SortHV(List<HoiVien> list, string condition)
        {
            switch (condition)
            {
                case "ten":
                    HoiVien[] tmp = list.ToArray();
                    GenericSort(tmp, HoiVien.CompareName);
                    return tmp.ToList();
                    break;
                case "ngaysinh":
                    HoiVien[] tmp1 = list.ToArray();
                    GenericSort(tmp1, HoiVien.CompareBirthday);
                    return tmp1.ToList();
                    break;
                case "mahv":
                    HoiVien[] tmp2 = list.ToArray();
                    GenericSort(tmp2, HoiVien.CompareMaHV);
                    return tmp2.ToList();
                    break;

                case "diachi":
                    HoiVien[] tmp3 = list.ToArray();
                    GenericSort(tmp3, HoiVien.CompareDC);
                    return tmp3.ToList();
                    break;
            }
            return null;
        }

        public List<NhanVien> SortNV(List<NhanVien> list, string condition)
        {
            switch (condition)
            {
                case "ten":
                    NhanVien[] tmp = list.ToArray();
                    GenericSort(tmp, NhanVien.CompareName);
                    return tmp.ToList();
                    break;
                case "ngaysinh":
                    NhanVien[] tmp1 = list.ToArray();
                    GenericSort(tmp1, NhanVien.CompareBirthday);
                    return tmp1.ToList();
                    break;
                case "mahv":
                    NhanVien[] tmp2 = list.ToArray();
                    GenericSort(tmp2, NhanVien.CompareMaHV);
                    return tmp2.ToList();
                    break;

                case "diachi":
                    NhanVien[] tmp3 = list.ToArray();
                    GenericSort(tmp3, NhanVien.CompareDC);
                    return tmp3.ToList();
                    break;
                case "hsl":
                    NhanVien[] tmp4 = list.ToArray();
                    GenericSort(tmp4, NhanVien.CompareHSL);
                    return tmp4.ToList();
                    break;
            }
            return null;
        }

        public List<GoiTap> SortGT(List<GoiTap> list, string condition)
        {
            switch (condition)
            {
                case "ten":
                    GoiTap[] tmp = list.ToArray();
                    GenericSort(tmp, GoiTap.CompareName);
                    return tmp.ToList();
                case "gia":
                    GoiTap[] tmp1 = list.ToArray();
                    GenericSort(tmp1, GoiTap.CompareGiaThanh);
                    return tmp1.ToList();
            }
            return null;
        }

        public List<PhongTap> SortPT(List<PhongTap> list, string condition)
        {
            switch (condition)
            {
                case "ten":
                    PhongTap[] tmp = list.ToArray();
                    GenericSort(tmp, PhongTap.CompareName);
                    return tmp.ToList();
            }
            return null;
        }

        public List<TrangThietBi> SortTTB(List<TrangThietBi> list, string condition)
        {
            switch (condition)
            {
                case "ten":
                    TrangThietBi[] tmp = list.ToArray();
                    GenericSort(tmp, TrangThietBi.CompareName);
                    return tmp.ToList();
            }
            return null;
        }

        public List<ChucVu> SortCV(List<ChucVu> list, string condition)
        {
            switch (condition)
            {
                case "ten":
                    ChucVu[] tmp = list.ToArray();
                    GenericSort(tmp, ChucVu.CompareName);
                    return tmp.ToList();
                case "hscv":
                    ChucVu[] tmp1 = list.ToArray();
                    GenericSort(tmp1, ChucVu.CompareHSCV);
                    return tmp1.ToList();
            }
            return null;
        }

        public string checkLogin(string tenDangNhap, string matKhau)
        {
            matKhau = Common.GetMD5(matKhau);
            TaiKhoan tk = mQuanLiGym.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == tenDangNhap && x.MatKhau == matKhau);
            if (tk != null)
            {
                string token = Common.GetToken();
                tk.token = token;
                tk.ThoiGianLogIn = DateTime.Now;
                mQuanLiGym.SaveChanges();
                return token;
            }
            else
            {
                return "";
            }
        }
    }
}