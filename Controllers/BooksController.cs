using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApplication;
using System.IO;
using Microsoft.AspNetCore.Http;
using ClosedXML.Excel;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace LibraryApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly DBLibraryContext _context;

        public BooksController(DBLibraryContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "admin, user")]
        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }
        [Authorize(Roles = "admin, user")]
        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewBag.ThisGenres = _context.GenresBooks.Where(obj=> obj.BookId == id).Join(_context.Genres, b => b.GenreId, g => g.Id, (b,g) => new 
            {
                Id = b.GenreId,
                Name = g.Name
            });

            ViewBag.ThisAuthors = _context.AuthorsBooks.Where(obj=>obj.BookId==id).Join(_context.Authors, b=>b.AuthorId, a => a.Id, (b, a) => new
            {
                Id = b.AuthorId,
                FullName = a.FirstName + " " + a.LastName
            });

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        [Authorize(Roles = "admin")]
        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            return View();
        }
        [Authorize(Roles = "admin")]
        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Info,Fb2,Pdf,PagesQuantity,Picture")] Book book, int[] genres, int[] authors)
        {
            var AreRepeats = _context.Books.Where(obj => obj.Name == book.Name && obj.PagesQuantity == book.PagesQuantity);
            foreach (var a in AreRepeats)
            {
                bool flag = false;
                var aBooks = _context.AuthorsBooks.Where(obj => obj.BookId == a.Id);
                foreach (var author in authors)
                {
                    if (aBooks.Where(obj => obj.AuthorId == author).Count() > 0) flag = true;
                    break;
                }
                if (flag)
                {
                    ModelState.AddModelError("", "Така книга вже існує");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(book);
               
                    foreach (int GId in genres)
                    {
                        GenresBook gb = new GenresBook { GenreId = GId, BookId = book.Id };
                        book.GenresBooks.Add(gb);
                    }
                

                    foreach (int AId in authors)
                    {
                        AuthorsBook ab = new AuthorsBook { AuthorId = AId, BookId = book.Id };
                        book.AuthorsBooks.Add(ab);
                    }
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            return View(book);
        }
        [Authorize(Roles = "admin")]
        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);

            var thisGenres = _context.GenresBooks.Where(obj => obj.BookId == id).Join(_context.Genres, b => b.GenreId, g => g.Id, (b, g) => new
            {
                   Id = b.GenreId,
                Name = g.Name
            });

            List<string> thisNames = new List<string>();
            foreach (var g in thisGenres) thisNames.Add(g.Name);

            ViewBag.ThisGenres = thisGenres;
            ViewBag.OtherGenres = _context.Genres.Where(obj=>!thisNames.Contains(obj.Name)).ToList();

            var thisAuthors = _context.AuthorsBooks.Where(obj => obj.BookId == id).Join(_context.Authors, b => b.AuthorId, a => a.Id, (b, a) => new
            {
                Id = b.AuthorId,
                FullName = a.FirstName + " " + a.LastName
            });

            List<string> thisFullNames = new List<string>();
            foreach (var a in thisAuthors) thisFullNames.Add(a.FullName);

            ViewBag.ThisAuthors = thisAuthors;
            ViewBag.OtherAuthors = _context.Authors.Where(obj=>!thisFullNames.Contains(obj.FirstName + " " + obj.LastName)).ToList();

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [Authorize(Roles = "admin")]
        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Info,Fb2,Pdf,PagesQuantity,Picture")] Book book, int[] genres, int[] authors)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            var AreRepeats = _context.Books.Where(obj => obj.Id!=book.Id && obj.Name == book.Name && obj.PagesQuantity == book.PagesQuantity);
            foreach (var a in AreRepeats)
            {
                bool flag = false;
                var aBooks = _context.AuthorsBooks.Where(obj => obj.BookId == a.Id);
                foreach (var author in authors)
                {
                    if (aBooks.Where(obj => obj.AuthorId == author).Count() > 0) flag = true;
                    break;
                }
                if (flag)
                {
                    ModelState.AddModelError("", "Така книга вже існує");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    foreach (var item in _context.GenresBooks)
                    {
                        if (item.BookId == book.Id) _context.GenresBooks.Remove(item);
                    }
                    foreach (var item in _context.AuthorsBooks)
                    {
                        if (item.BookId == book.Id) _context.AuthorsBooks.Remove(item);
                    }
                    
                        foreach (int GId in genres)
                        {
                            GenresBook gb = new GenresBook { GenreId = GId, BookId = book.Id };
                            book.GenresBooks.Add(gb);
                        }

                    
                        foreach (int AId in authors)
                        {
                            AuthorsBook ab = new AuthorsBook { AuthorId = AId, BookId = book.Id };
                            book.AuthorsBooks.Add(ab);
                        }
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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

            var thisGenres = _context.GenresBooks.Where(obj => obj.BookId == id).Join(_context.Genres, b => b.GenreId, g => g.Id, (b, g) => new
            {
                Id = b.GenreId,
                Name = g.Name
            });

            List<string> thisNames = new List<string>();
            foreach (var g in thisGenres) thisNames.Add(g.Name);

            ViewBag.ThisGenres = thisGenres;
            ViewBag.OtherGenres = _context.Genres.Where(obj => !thisNames.Contains(obj.Name)).ToList();

            var thisAuthors = _context.AuthorsBooks.Where(obj => obj.BookId == id).Join(_context.Authors, b => b.AuthorId, a => a.Id, (b, a) => new
            {
                Id = b.AuthorId,
                FullName = a.FirstName + " " + a.LastName
            });

            List<string> thisFullNames = new List<string>();
            foreach (var a in thisAuthors) thisFullNames.Add(a.FullName);

            ViewBag.ThisAuthors = thisAuthors;
            ViewBag.OtherAuthors = _context.Authors.Where(obj => !thisFullNames.Contains(obj.FirstName + " " + obj.LastName)).ToList();
            return View(book);
        }
        [Authorize(Roles = "admin")]
        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewBag.ThisGenres = _context.GenresBooks.Where(obj => obj.BookId == id).Join(_context.Genres, b => b.GenreId, g => g.Id, (b, g) => new
            {
                Name = g.Name
            });

            ViewBag.ThisAuthors = _context.AuthorsBooks.Where(obj => obj.BookId == id).Join(_context.Authors, b => b.AuthorId, a => a.Id, (b, a) => new
            {
                FullName = a.FirstName + " " + a.LastName
            });

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        [Authorize(Roles = "admin")]
        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            var authorBooks = _context.AuthorsBooks.Where(obj => obj.BookId == id);
            foreach (var item in authorBooks)
            {
                _context.AuthorsBooks.Remove(item);
            }
            var genresBooks = _context.GenresBooks.Where(obj => obj.BookId == id);
            foreach (var item in genresBooks)
            {
                _context.GenresBooks.Remove(item);
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "admin, user")]
        public VirtualFileResult Download(int id)
        {
            var book =  _context.Books.Where(obj=>obj.Id==id).FirstOrDefault();
            var filepath = book.Fb2;
            return File(filepath, "application/fb2", book.Name.Replace(' ', '_') + ".fb2");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile fileExcel)
        {
            if (ModelState.IsValid)
            {
                if (fileExcel != null)
                {
                    using (var stream = new FileStream(fileExcel.FileName, FileMode.Create))
                    {
                        await fileExcel.CopyToAsync(stream);
                        using (XLWorkbook workBook = new XLWorkbook(stream, XLEventTracking.Disabled))
                        {
                            List<string> missingAuthors = new List<string>();
                            List<string> unvalidPath = new List<string>();
                            List<string> quantity = new List<string>();
                            List<string> doubles = new List<string>();
                            string NameProblem = "";
                            foreach (IXLWorksheet worksheet in workBook.Worksheets)
                            {
                                Author newAuthor;
                                var author = _context.Authors.Where(obj => (obj.FirstName + " " + obj.LastName).ToLower() == worksheet.Name.ToLower()).ToList();
                                if (author.Count > 0)
                                {
                                    newAuthor = author[0];
                                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                                    {
                                        try
                                        {
                                            if (row.Cell(1).Value.ToString() == null || row.Cell(1).Value.ToString().Length < 3)
                                            {
                                                NameProblem = "Деякі з книжок не були додані, бо назва була відсутня або закоротка";
                                                continue;
                                            }
                                            bool flag = false;
                                            Book book = new Book();
                                            Regex fb2 = new Regex(@"^(/css/fb2Books/)\S+.fb2$");
                                            Regex pdf = new Regex(@"^(/css/pdfBooks/)\S+.pdf$");
                                            Regex pic = new Regex(@"^(/css/covers/)\S+.(png|jpeg|jpg)$");
                                            if (fb2.IsMatch(row.Cell(5).Value.ToString()) && pdf.IsMatch(row.Cell(6).Value.ToString()) && pic.IsMatch(row.Cell(7).Value.ToString()))
                                            {
                                                flag = true;
                                                book.Fb2 = row.Cell(5).Value.ToString();
                                                book.Pdf = row.Cell(6).Value.ToString();
                                                book.Picture = row.Cell(7).Value.ToString();
                                            }
                                            else unvalidPath.Add(row.Cell(1).Value.ToString());
                                            if (flag == true)
                                            {

                                                var areDoubles = _context.AuthorsBooks.Where(obj => obj.Id == newAuthor.Id).Join(_context.Books, b => b.BookId, c => c.Id, (b, c) => new
                                                {
                                                    Name = c.Name
                                                });
                                                if (areDoubles.Where(obj => obj.Name == row.Cell(1).Value.ToString()).ToList().Count > 0) doubles.Add(row.Cell(1).Value.ToString());
                                                else if (_context.Books.Where(obj => obj.Fb2 == row.Cell(5).Value.ToString() || obj.Pdf == row.Cell(6).Value.ToString()).ToList().Count > 0) doubles.Add(row.Cell(1).Value.ToString());
                                                else
                                                {
                                                    book.Name = row.Cell(1).Value.ToString();
                                                    int qnt;
                                                    bool success = Int32.TryParse(row.Cell(8).Value.ToString(), out qnt);
                                                    if (success && qnt > 0) book.PagesQuantity = qnt;
                                                    else
                                                    {
                                                        book.PagesQuantity = 2;
                                                        quantity.Add(book.Name);
                                                    }
                                                    if (row.Cell(9).Value.ToString() != null) book.Info = row.Cell(9).Value.ToString();
                                                    else book.Info = "Інформація за замовчуванням";
                                                    _context.Books.Add(book);
                                                    AuthorsBook ab = new AuthorsBook();
                                                    ab.Book = book;
                                                    ab.Author = newAuthor;
                                                    _context.AuthorsBooks.Add(ab);

                                                    for (int i = 2; i <= 4; i++)
                                                    {
                                                        if (row.Cell(i).Value.ToString().Length > 0)
                                                        {
                                                            Genre genre;

                                                            var g = _context.Genres.Where(obj => obj.Name.ToLower().Contains(row.Cell(i).Value.ToString().ToLower())).ToList();
                                                            if (g.Count > 0)
                                                            {
                                                                genre = g[0];
                                                            }
                                                            else
                                                            {
                                                                genre = new Genre();
                                                                genre.Name = row.Cell(i).Value.ToString();
                                                                genre.Info = "Інформація поки відсутня";
                                                                //додати в контекст
                                                                _context.Add(genre);
                                                            }
                                                            GenresBook gb = new GenresBook();
                                                            gb.Book = book;
                                                            gb.Genre = genre;
                                                            _context.GenresBooks.Add(gb);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            //logging самостійно :)

                                        }
                                    }
                                }
                                else
                                {
                                    missingAuthors.Add(worksheet.Name);
                                }
                            }
                            ViewBag.UnvalidPath = unvalidPath;
                            ViewBag.MissingAuthors = missingAuthors;
                            ViewBag.PagesChanged = quantity;
                            ViewBag.Doubles = doubles;
                            ViewBag.NameProblem = NameProblem; 
                        }
                    }
                }

            await _context.SaveChangesAsync();
        }
            return View();
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Export()
        {
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var  authors = _context.Authors.ToList();
                var books = _context.Books.Join(_context.AuthorsBooks, b => b.Id, a => a.BookId, (b, a) => new { BookName = b.Name, Pages = b.PagesQuantity, AuthorId = a.AuthorId, BookId = b.Id });
                foreach (var a in authors)
                {
                    var worksheet = workbook.Worksheets.Add(a.FirstName + " " + a.LastName);

                    worksheet.Cell("A1").Value = "Назва";
                    worksheet.Cell("B1").Value = "Жанр";
                    worksheet.Cell("C1").Value = "Країна";
                    worksheet.Cell("D1").Value = "Кількість сторінок";
                    worksheet.Row(1).Style.Font.Bold = true;
                    var thisBooks = books.Where(obj => obj.AuthorId == a.Id).ToList();
                    for (int i = 0; i < thisBooks.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = thisBooks[i].BookName;
                        worksheet.Cell(i + 2, 4).Value = thisBooks[i].Pages;
                        var genres = _context.GenresBooks.Where(obj => obj.BookId == thisBooks[i].BookId).ToList();
                        if (genres.Count > 0)
                        {
                            worksheet.Cell(i + 2, 2).Value = _context.Genres.Where(obj => obj.Id == genres[0].GenreId).FirstOrDefault().Name;
                            for (int j = 1; j < genres.Count; j++)
                            {
                                worksheet.Cell(i + 2, 2).Value = worksheet.Cell(i + 2, 2).Value.ToString() + " " + _context.Genres.Where(obj => obj.Id == genres[j].GenreId).FirstOrDefault().Name;
                            }
                        }
                        else worksheet.Cell(i + 2, 2).Value = "Невідомо";
                        var countries = _context.AuthorsCountries.Where(obj => obj.AuthorId == a.Id).ToList();
                        if (countries.Count > 0)
                        {
                            worksheet.Cell(i + 2, 3).Value = _context.Countries.Where(obj => obj.Id == countries[0].CountryId).FirstOrDefault().Name;
                            for (int j = 1; j < countries.Count; j++)
                            {
                                worksheet.Cell(i + 2, 3).Value = worksheet.Cell(i + 2, 3).Value.ToString() + " " + _context.Countries.Where(obj => obj.Id == countries[j].CountryId).FirstOrDefault().Name;
                            }
                        }
                        else worksheet.Cell(i + 2, 3).Value = "Невідомо";
                    }
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"library_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }

    }
}
