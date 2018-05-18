using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGym.Models
{
    [Table("TrangThietBi")]
    public class TrangThietBi
    {
        [StringLength(15)]
        [Key]
        public string MaThietBi { get; set; }

        [Required]
        [StringLength(120)]
        public string TenThietBi { get; set; }

        [Required]
        public bool TinhTrangSuDung { get; set; } 

        [Required]
        [StringLength(15)]
        public string MaPhongTap { get; set; }

        [ForeignKey("MaPhongTap")]
        public PhongTap phongTap { get; set; }

        public string toStringTrangThietBi()
        {
            return this.MaThietBi + this.TenThietBi + this.MaPhongTap;
        }

        public static bool CompareName(object a, object b)
        {
            if (String.Compare(((TrangThietBi)a).TenThietBi, ((TrangThietBi)b).TenThietBi) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}