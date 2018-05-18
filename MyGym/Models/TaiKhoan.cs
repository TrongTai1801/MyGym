using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGym.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(60)]
        public string token { get; set; }

        public DateTime? ThoiGianLogIn { get; set; }

        [Required]
        [StringLength(2)]
        public string permission { get; set; }

        public TaiKhoan() { }

        public TaiKhoan(string TenDangNhap, string MatKhau, string token, DateTime ThoiGianLogIn, string per)
        {
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.token = token;
            this.ThoiGianLogIn = ThoiGianLogIn;
            this.permission = per;
        }

        public string toStringTaiKhoan()
        {
                return this.TenDangNhap + this.permission;
        }
    }
}