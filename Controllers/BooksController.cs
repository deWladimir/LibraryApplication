using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApplication;
using System.IO;

namespace LibraryApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly DBLibraryContext _context;

        public BooksController(DBLibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

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

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            return View();
        }

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
    }
}
