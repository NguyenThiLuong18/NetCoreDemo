using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreDemo.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Display(Name = "Mã Sản phẩm")]

        public string ProductID { get; set; }
        [Display(Name = "Tên Sản phẩm")]
        public string ProductName {get; set;}
        [Display(Name = "Đơn Giá")]
        public string UnitPrice {get; set;}
        [Display(Name = "Số lượng")]
        public string Quantity {get; set;}

    }
}