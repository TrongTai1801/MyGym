using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGym.Models
{
    [Table("NhanVien")]
    public class NhanVien 
    {
        [Key]
        [StringLength(15)]
        public string Ma { get; set; }

        [Required]
        [StringLength(120)]
        public string Ten { get; set; }

        [Required]
        [StringLength(120)]
        public string CMND { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        public bool GioiTinh { get; set; }

        [Required]
        [StringLength(120)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(120)]
        public string SDT { get; set; }

        [Required]
        [StringLength(120)]
        public string MaChucVu { get; set; }

        [ForeignKey("MaChucVu")]
        public virtual ChucVu ChucVu { get; set; }

        [Required]
        public Double HeSoLuong { get; set; }

        public string toStringNhanVien()
        {
            if (this.GioiTinh)
            {
                return this.Ma + this.Ten + this.CMND + Convert.ToString(this.NgaySinh)
                + "nam" + this.DiaChi + this.SDT + this.MaChucVu;
            }
            return this.Ma + this.Ten + this.CMND + Convert.ToString(this.NgaySinh)
                + "nu" + this.DiaChi + this.SDT + this.MaChucVu;
        }

        public static bool CompareName(object a, object b)
        {
            if (String.Compare(((NhanVien)a).Ten, ((NhanVien)b).Ten) > 0)
            {
                return true;
            }
            else return false;
        }
        public static bool CompareBirthday(object a, object b)
        {
            if (String.Compare(Convert.ToString(((NhanVien)a).NgaySinh.ToString()), Convert.ToString(((NhanVien)b).NgaySinh.ToString())) > 0)
            {
                return true;
            }
            else return false;
        }
        public static bool CompareMaHV(object a, object b)
        {
            if (String.Compare(((NhanVien)a).Ma, ((NhanVien)b).Ma) > 0)
            {
                return true;
            }
            else return false;
        }

        public static bool CompareDC(object a, object b)
        {
            if (String.Compare(((NhanVien)a).DiaChi, ((NhanVien)b).DiaChi) > 0)
            {
                return true;
            }
            else return false;
        }

        public static bool CompareHSL(object a, object b)
        {
            if ((((NhanVien)a).HeSoLuong > ((NhanVien)b).HeSoLuong))
            {
                return true;
            }
            else return false;
        }
    }
}