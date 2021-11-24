using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreDemo.Models
{
    public class DonHang : Person
    {
        [Display(Name = "Mã Đơn Hàng")]
        public string MaDonHang{ get; set; }
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai{ get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi {get; set;}

    }
}