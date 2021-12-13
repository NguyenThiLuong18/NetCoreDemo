using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Models;
using NetCoreDemo.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NetCoreDemo.Controllers
{
    public class MoviesController : Controller
    {
        private readonly NetCoreDbContext _context;
        private ExcelProcess _excelPro = new ExcelProcess();
        public MoviesController(NetCoreDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public IConfiguration Configuration {get;}

         // GET: Movie
        // GET: Movies
    public async Task<IActionResult> Index(string movieGenre, string SearchString)
    {
        // sử dụng LinQ để select ra Genre.
        IQueryable<string> genreQuery = from m in _context.Movie
                                        orderby m.Genre
                                        select m.Genre;

        // sử dụng LinQ để select ra danh sách bản ghi Movie trong database.
        var movies = from m in _context.Movie
                    select m;

        if (!string.IsNullOrEmpty(SearchString))
        {
            movies = movies.Where(s => s.Title.Contains(SearchString));
        }

        if (!string.IsNullOrEmpty(movieGenre))
        {
            movies = movies.Where(x => x.Genre == movieGenre);
        }

        var movieGenreVM = new MovieGenreViewModel
        {
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
            Movies = await movies.ToListAsync()
        };
        
        return View(movieGenreVM);
    }


        public IActionResult UploadFile(){
            return View();
        }
        [HttpPost]
        public IActionResult UploadFile(IFormFile file){
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Chọn đúng File: "+ fileExtension);
                }
                    else
                {
                    //rename file when upload to server
                    //tao duong dan /Uploads/Excels de luu file upload len server
                    var fileName = "Movie";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
                    var fileLocation = new FileInfo(filePath).ToString();

                    if (ModelState.IsValid)
                    {
                        //upload file to server
                        if (file.Length > 0)
                        {
                            using (var stream = new FileStream(filePath,FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                //save file to server
                                file.CopyToAsync(stream);
                                //read data from file and write to database
                                //_excelPro la doi tuong xu ly file excel ExcelProcess
                                var dt = _excelPro.ExcelToDataTable(fileLocation);
                                //ghi du lieu datatable vao database
                                //var sobanghithanhcong = WriteDatatableToDatabase(dt);
                                for(int i = 0; i< dt.Rows.Count; i++){
                                    var movies = new Movie();
                                    movies.Id = Convert.ToInt32(dt.Rows[i][0].ToString());
                                    movies.Title = dt.Rows[i][1].ToString();
                                    movies.ReleaseDate = Convert.ToDateTime(dt.Rows[i][2].ToString());
                                    movies.Price = Convert.ToDecimal(dt.Rows[i][3].ToString());
                                    movies.Genre = dt.Rows[i][4].ToString();
                                    movies.Rating = dt.Rows[i][5].ToString();
                                    _context.Add(movies);
                                }
                                _context.SaveChanges();
                                var sobanghithanhcong = dt.Rows.Count;
                                ModelState.AddModelError("", "Ghi thanh cong du lieu, bao gom: " + sobanghithanhcong + " ban ghi");
                                
                            }
                            //return RedirectToAction(nameof(UploadFile));
                        }
                    }
                }
                
                
                
            }
                return View();
        }

        

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file)
        {
            
            if (file!=null)
            {
              
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to server
                    //tao duong dan /Uploads/Excels de luu file upload len server
                    var fileName = "Movie";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
                    var fileLocation = new FileInfo(filePath).ToString();

                    if (ModelState.IsValid)
                    {
                        //upload file to server
                        if (file.Length > 0)
                        {
                            using (var stream = new FileStream(filePath,FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                //read data from file and write to database
                                //_excelPro la doi tuong xu ly file excel ExcelProcess
                                var dt = _excelPro.ExcelToDataTable(fileLocation);
                                //ghi du lieu datatable vao database
                                
                            }
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
            else {
                 ModelState.AddModelError("", "Chọn đúng file!");
            }
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
        // private int WriteDatatableToDatabase (DataTable dt){
        //    // try{
        //         var con = Configuration.GetConnectionString("NetCoreDbContext");
        //         SqlBulkCopy bulkcopy = new SqlBulkCopy (con);
        //         bulkcopy.DestinationTableName = "Movies";
        //         bulkcopy.ColumnMappings.Add(0, "Title");
        //         bulkcopy.ColumnMappings.Add(1, "ReleaseDate");
        //         bulkcopy.ColumnMappings.Add(2, "Price");
        //         bulkcopy.ColumnMappings.Add(3, "Genre");
        //         bulkcopy.ColumnMappings.Add(4, "Rating");
        //         bulkcopy.WriteToServer (dt);
        //     // }
        //     // catch{
        //     //     return 0;
        //     // }
        //     return dt.Rows.Count;
        // }
    }
    
}
