using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGym.Models
{
    [Table("PhongTap")]
    public class PhongTap
    {
        [Key]
        [StringLength(15)]
        public string MaPhongTap { get; set; }

        [Required]
        [StringLength(120)]
        public string TenPhongTap { get; set; }

        public virtual ICollection<TrangThietBi> TrangThietBis { get; set; }

        public string toStringPhongTap()
        {
            return this.MaPhongTap + this.TenPhongTap;
        }

        public static bool CompareName(object a, object b)
        {
            if (String.Compare(((PhongTap)a).TenPhongTap, ((PhongTap)b).TenPhongTap) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}