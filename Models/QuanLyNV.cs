using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreDemo.Models
{
    [Table("QuanLyNVs")]
    public class QuanLyNV
    {
        [Key]
        [Display(Name = "Mã phòng")]

        public string MaPhong { get; set; }
        [Display(Name = "Tên phòng ban")]
        public string TenPhongBan {get; set;}
        [Display(Name = "Mã Nhân Viên")]

        public string EmployeeID { get; set; }
        public Employee Employee { get; set; }

    }
}