using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGym.Models
{
    [Table("HoiVien")]
    public class HoiVien 
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
        [StringLength(15)]
        public string MaGoi { get; set; }

        public HoiVien() { }

        public HoiVien(string mahv, string name, string cmnd, DateTime birthDay, bool gender, string mobile, string address, string ma_goi)
        {
            this.Ma = mahv;
            this.Ten = name;
            this.NgaySinh = birthDay;
            this.GioiTinh = gender;
            this.DiaChi = address;
            this.SDT = mobile;
            this.MaGoi = ma_goi;
            this.CMND = cmnd;
            //this.MaQH = "user";
        }

        [ForeignKey("MaGoi")]
        public virtual GoiTap GoiTap { get; set; }

        public string toStringHoiVien()
        {
            if (this.GioiTinh)
            {
                return this.Ma + this.Ten + this.CMND + Convert.ToString(this.NgaySinh)
                + "nam" + this.DiaChi + this.SDT + this.MaGoi;
            }
            return this.Ma + this.Ten + this.CMND + Convert.ToString(this.NgaySinh)
                + "nu" + this.DiaChi + this.SDT + this.MaGoi;
        }

        public static bool CompareName(object a, object b)
        {
            if (String.Compare(((HoiVien)a).Ten, ((HoiVien)b).Ten) > 0)
            {
                return true;
            }
            else return false;
        }
        public static bool CompareBirthday(object a, object b)
        {
            if (String.Compare(Convert.ToString(((HoiVien)a).NgaySinh.ToString()), Convert.ToString(((HoiVien)b).NgaySinh.ToString())) > 0)
            {
                return true;
            }
            else return false;
        }
        public static bool CompareMaHV(object a, object b)
        {
            if (String.Compare(((HoiVien)a).Ma, ((HoiVien)b).Ma) > 0)
            {
                return true;
            }
            else return false;
        }

        public static bool CompareDC(object a, object b)
        {
            if (String.Compare(((HoiVien)a).DiaChi, ((HoiVien)b).DiaChi) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}