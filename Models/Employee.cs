using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreDemo.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Display(Name = "Mã Nhân viên")]

        public string EmployeeID { get; set; }
        [Display(Name = "Tên Nhân viên")]
        public string EmployeeName {get; set;}
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber {get; set;}
        public ICollection <QuanLyNV> QuanLyNVs {get; set;}


    }
}