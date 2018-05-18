using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyGym.Models
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        public string MaChucVu { get; set; }

        [Required]
        [StringLength(120)]
        public string TenChucVu { get; set; }

        [Required]
        public Double HeSoChucVu { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }

        public string toStringChucVu()
        {
            return this.MaChucVu + this.TenChucVu + this.HeSoChucVu.ToString();
        }

        public static bool CompareHSCV(object a, object b)
        {
            if ((((ChucVu)a).HeSoChucVu > ((ChucVu)b).HeSoChucVu))
            {
                return true;
            }
            else return false;
        }

        public static bool CompareName(object a, object b)
        {
            if (String.Compare(((ChucVu)a).TenChucVu, ((ChucVu)b).TenChucVu) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}