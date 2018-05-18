using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyGym.Models
{
    public class InitializerDB : DropCreateDatabaseAlways<QuanLiGym>
    {
        protected override void Seed(QuanLiGym context)
        {
            //base.Seed(context);
            //Add HV
            context.HoiViens.Add(new HoiVien
            {
                Ma = "HV01",
                Ten = "Le Van A",
                CMND = "123456789",
                NgaySinh = Convert.ToDateTime("1996-05-01"),
                GioiTinh = true,
                DiaChi = "Quang Nam",
                SDT = "0123456789",
                MaGoi = "G01"
            });

            context.HoiViens.Add(new HoiVien
            {
                Ma = "HV06",
                Ten = "Nguyen Thi B",
                CMND = "987654321",
                NgaySinh = Convert.ToDateTime("1997-03-01"),
                GioiTinh = false,
                DiaChi = "Hue",
                SDT = "0987654321",
                MaGoi = "G02"
            });

            context.HoiViens.Add(new HoiVien
            {
                Ma = "HV03",
                Ten = "Van Van C",
                CMND = "456123789",
                NgaySinh = Convert.ToDateTime("1991-06-01"),
                GioiTinh = true,
                DiaChi = "Hue",
                SDT = "0456123789",
                MaGoi = "G03"
            });

            context.HoiViens.Add(new HoiVien
            {
                Ma = "HV04",
                Ten = "Nguyen Thi D",
                CMND = "456789123",
                NgaySinh = DateTime.Now,
                GioiTinh = false,
                DiaChi = "Hue",
                SDT = "0456789123",
                MaGoi = "G02"
            });

            //Add GT
            context.GoiTaps.Add(new GoiTap
            {
                MaGoi = "G01",
                TenGoi = "thang",
                GiaThanh = 230000
            });

            context.GoiTaps.Add(new GoiTap
            {
                MaGoi = "G02",
                TenGoi = "quy",
                GiaThanh = 600000
            });

            context.GoiTaps.Add(new GoiTap
            {
                MaGoi = "G03",
                TenGoi = "6 thang",
                GiaThanh = 500000
            });

            //Add TK
            context.TaiKhoans.Add(new TaiKhoan
            {
                TenDangNhap = "admin01",
                MatKhau = Common.GetMD5("12345"),
                token = "",
                ThoiGianLogIn = DateTime.Now,
                permission = "1"
            });
            context.TaiKhoans.Add(new TaiKhoan
            {
                TenDangNhap = "admin02",
                MatKhau = Common.GetMD5("12345"),
                token = "",
                ThoiGianLogIn = DateTime.Now,
                permission = "1"
            });
            context.TaiKhoans.Add(new TaiKhoan
            {
                TenDangNhap = "user01",
                MatKhau = Common.GetMD5("12345"),
                token = "",
                ThoiGianLogIn = DateTime.Now,
                permission = "2"
            });
            context.TaiKhoans.Add(new TaiKhoan
            {
                TenDangNhap = "user02",
                MatKhau = Common.GetMD5("12345"),
                token = "",
                ThoiGianLogIn = DateTime.Now,
                permission = "2"
            });
            //Add NV
            context.NhanViens.Add(new NhanVien
            {
                Ma = "QL01",
                Ten = "Nguyen Van A",
                CMND = "1345679",
                NgaySinh = DateTime.Now,
                GioiTinh = true,
                DiaChi = "HCM",
                MaChucVu = "QL",
                SDT = "01659874563",
                HeSoLuong = 1.35,
            });

            context.NhanViens.Add(new NhanVien
            {
                Ma = "QL02",
                Ten = "Nguyen Van B",
                CMND = "1345679",
                NgaySinh = DateTime.Now,
                GioiTinh = true,
                DiaChi = "HCM",
                MaChucVu = "QL",
                SDT = "01659874563",
                HeSoLuong = 1.9,
            });
            
            context.NhanViens.Add(new NhanVien
            {
                Ma = "LC02",
                Ten = "Tran Van C",
                CMND = "1345679",
                NgaySinh = DateTime.Now,
                GioiTinh = true,
                DiaChi = "Binh Dinh",
                MaChucVu = "QL",
                SDT = "01659874563",
                HeSoLuong = 1.25,
            });

            context.NhanViens.Add(new NhanVien
            {
                Ma = "HLV09",
                Ten = "Le Van D",
                CMND = "1345679",
                NgaySinh = DateTime.Now,
                GioiTinh = true,
                DiaChi = "Hue",
                MaChucVu = "QL",
                SDT = "01659874563",
                HeSoLuong = 1.25,
            });

            //Add CV
            context.ChucVus.Add(new ChucVu {
                MaChucVu = "QL", 
                TenChucVu = "Quan li",
                HeSoChucVu = 2.5
            });

            context.ChucVus.Add(new ChucVu
            {
                MaChucVu = "HLV",
                TenChucVu = "Huan luyen vien",
                HeSoChucVu = 1.75
            });

            context.ChucVus.Add(new ChucVu
            {
                MaChucVu = "LC",
                TenChucVu = "Lao cong",
                HeSoChucVu = 1
            });

            //Add PT
            context.PhongTaps.Add(new PhongTap {
                MaPhongTap = "T01",
                TenPhongTap = "Phong Pho Thong 1",
            });

            context.PhongTaps.Add(new PhongTap
            {
                MaPhongTap = "V01",
                TenPhongTap = "Phong VIP 1",
            });

            //Add TTB
            context.TrangThietBis.Add(new TrangThietBi {
                MaThietBi = "Ta001",
                TenThietBi = "Ta tay",
                TinhTrangSuDung = true,
                MaPhongTap = "V01"
            });

            context.TrangThietBis.Add(new TrangThietBi
            {
                MaThietBi = "CB001",
                TenThietBi = "May chay bo",
                TinhTrangSuDung = false,
                MaPhongTap = "T01"
            });

            context.SaveChanges();
        }
    }
}