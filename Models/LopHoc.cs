using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreDemo.Models
{
    [Table("LopHocs")]
    public class LopHoc
    {
        [Key]
        [Display(Name = "Mã Lớp")]

        public string LopHocID { get; set; }
        [Display(Name = "Tên Lớp")]
        public string LopHocName {get; set;}
        [Display(Name = "Mã Sinh Viên")]

        public string StudentID { get; set; }
        public Student Student { get; set; }

    }
}