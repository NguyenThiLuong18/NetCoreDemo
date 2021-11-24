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
        [Display(Name = "Mã Sinh Viên")]
         [Required(ErrorMessage ="Không được bỏ trống")]
        public string StudentID { get; set; }
       
        [Display(Name = "Tên Sinh Viên")]
        public string StudentName {get; set;}
        [Display(Name = "Địa chỉ")]
        public string Address {get; set;}
        public ICollection <LopHoc> LopHocs { get; set; }

    }
}