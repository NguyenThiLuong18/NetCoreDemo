using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreDemo.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
         [StringLength(8, MinimumLength = 1)]
        [Display(Name = "Mã Sinh Viên")]
         [Required(ErrorMessage ="Không được bỏ trống")]
        public string StudentID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(60)]
        [Display(Name = "Tên Sinh Viên")]
        public string StudentName {get; set;}
        [Display(Name = "Địa chỉ")]
        public string Address {get; set;}
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai {get; set;}
        public ICollection <LopHoc> LopHocs { get; set; }

    }
}