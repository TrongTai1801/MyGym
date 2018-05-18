using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGym.Models
{
    [Table("GoiTap")]
    public class GoiTap
    {
        [Key]
        [StringLength(15)]
        public string MaGoi { get; set; }

        [Required]
        [StringLength(120)]
        public string TenGoi { get; set; }

        [Required]
        public double GiaThanh { get; set; }

        public GoiTap() { }

        public GoiTap(string magoi, string tengoi, double giathanh)
        {
            this.MaGoi = magoi;
            this.TenGoi = tengoi;
            this.GiaThanh = giathanh;
        }

        public virtual ICollection<HoiVien> HoiViens { get; set; }

        public string toStringGoiTap()
        {
            return this.MaGoi + this.TenGoi + this.GiaThanh.ToString();
        }

        public static bool CompareGiaThanh(object a, object b)
        {
            if ((((GoiTap)a).GiaThanh > ((GoiTap)b).GiaThanh))
            {
                return true;
            }
            else return false;
        }

        public static bool CompareName(object a, object b)
        {
            if (String.Compare(((GoiTap)a).TenGoi, ((GoiTap)b).TenGoi) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}