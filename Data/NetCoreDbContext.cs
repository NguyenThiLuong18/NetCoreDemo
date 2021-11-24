using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Models;
namespace NetCoreDemo.Data{
    public class NetCoreDbContext : DbContext
    {
        public NetCoreDbContext (DbContextOptions<NetCoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<NetCoreDemo.Models.Movie> Movie { get; set; }

        public DbSet<NetCoreDemo.Models.Person> Person { get; set; }

        public DbSet<NetCoreDemo.Models.Student> Student { get; set; }

        public DbSet<NetCoreDemo.Models.Employee> Employee { get; set; }

        public DbSet<NetCoreDemo.Models.Product> Product { get; set; }
        public DbSet<NetCoreDemo.Models.DonHang> DonHang { get; set; }
        public DbSet<NetCoreDemo.Models.LopHoc> LopHoc { get; set; }
        public DbSet<NetCoreDemo.Models.QuanLyNV> QuanLyNV { get; set; }
        public DbSet<NetCoreDemo.Models.HoaDon> HoaDon { get; set; }
    }

}
