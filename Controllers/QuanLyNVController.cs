using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Data;
using NetCoreDemo.Models;

namespace NetCoreDemo.Controllers
{
    public class QuanLyNVController : Controller
    {
        private readonly NetCoreDbContext _context;

        public QuanLyNVController(NetCoreDbContext context)
        {
            _context = context;
        }

        // GET: QuanLyNV
        public async Task<IActionResult> Index()
        {
            var netCoreDbContext = _context.QuanLyNV.Include(q => q.Employee);
            return View(await netCoreDbContext.ToListAsync());
        }

        // GET: QuanLyNV/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyNV = await _context.QuanLyNV
                .Include(q => q.Employee)
                .FirstOrDefaultAsync(m => m.MaPhong == id);
            if (quanLyNV == null)
            {
                return NotFound();
            }

            return View(quanLyNV);
        }

        // GET: QuanLyNV/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            return View();
        }

        // POST: QuanLyNV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhong,TenPhongBan,EmployeeID")] QuanLyNV quanLyNV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanLyNV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", quanLyNV.EmployeeID);
            return View(quanLyNV);
        }

        // GET: QuanLyNV/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyNV = await _context.QuanLyNV.FindAsync(id);
            if (quanLyNV == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", quanLyNV.EmployeeID);
            return View(quanLyNV);
        }

        // POST: QuanLyNV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaPhong,TenPhongBan,EmployeeID")] QuanLyNV quanLyNV)
        {
            if (id != quanLyNV.MaPhong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanLyNV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanLyNVExists(quanLyNV.MaPhong))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", quanLyNV.EmployeeID);
            return View(quanLyNV);
        }

        // GET: QuanLyNV/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyNV = await _context.QuanLyNV
                .Include(q => q.Employee)
                .FirstOrDefaultAsync(m => m.MaPhong == id);
            if (quanLyNV == null)
            {
                return NotFound();
            }

            return View(quanLyNV);
        }

        // POST: QuanLyNV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quanLyNV = await _context.QuanLyNV.FindAsync(id);
            _context.QuanLyNV.Remove(quanLyNV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanLyNVExists(string id)
        {
            return _context.QuanLyNV.Any(e => e.MaPhong == id);
        }
    }
}
