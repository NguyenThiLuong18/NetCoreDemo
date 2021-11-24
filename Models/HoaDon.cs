using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreDemo.Models
{
    public class HoaDon : Product
    {
        [Display(Name = "Mã Hóa Đơn")]
        public string MaHoaDon{ get; set; }
        [Display(Name = "Tổng Tiền")]
        public string TongTien{ get; set; }

    }
}