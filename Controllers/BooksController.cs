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

            var genresBooks = _context.GenresBooks.Where(obj => obj.BookId == book.Id);
            Dictionary<int, string> thisGenres = new Dictionary<int, string>();
            foreach (var g in genresBooks)
            {
                thisGenres.Add(g.GenreId, _context.Genres.Where(obj => obj.Id == g.GenreId).FirstOrDefault().Name);
            }
            ViewBag.ThisGenres = thisGenres;

            var authorsBooks = _context.AuthorsBooks.Where(obj => obj.BookId == book.Id);
            Dictionary<int, string> thisAuthors = new Dictionary<int, string>();
            foreach (var a in authorsBooks)
            {
                var author = _context.Authors.Where(obj => obj.Id == a.AuthorId).FirstOrDefault();
                string fullName = author.FirstName + " " + author.LastName;
                thisAuthors.Add(a.AuthorId, fullName);
            }
            ViewBag.ThisAuthors = thisAuthors;

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.Genres = _context.Genres.Where(obj=>obj.Name!="Без жанру").ToList();
            ViewBag.Authors = _context.Authors.Where(obj=>obj.LastName!="Невідомий" && obj.FirstName!="Автор").ToList();
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Info,Fb2,Pdf,PagesQuantity,Picture")] Book book, int[] genres, int[] authors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                if (genres.Length == 0)
                {
                    GenresBook gb = new GenresBook { BookId = book.Id, GenreId = _context.Genres.Where(obj => obj.Name == "Без жанру").FirstOrDefault().Id };
                    book.GenresBooks.Add(gb);
                }

                else
                {
                    foreach (int GId in genres)
                    {
                        GenresBook gb = new GenresBook { GenreId = GId, BookId = book.Id };
                        book.GenresBooks.Add(gb);
                    }
                }


                if (authors.Length == 0)
                {
                    AuthorsBook ab = new AuthorsBook { BookId = book.Id, AuthorId = _context.Authors.Where(obj => obj.FirstName == "Автор" && obj.LastName == "Невідомий").FirstOrDefault().Id };
                    book.AuthorsBooks.Add(ab);
                }

                else
                {
                    foreach (int AId in authors)
                    {
                        AuthorsBook ab = new AuthorsBook { AuthorId = AId, BookId = book.Id };
                        book.AuthorsBooks.Add(ab);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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

            Dictionary<int, string> thisGenres = new Dictionary<int, string>();
            Dictionary<int, string> otherGenres = new Dictionary<int, string>();
            foreach(var item in _context.GenresBooks)
            {
                if (item.BookId == book.Id)
                {
                    string genre = _context.Genres.Where(obj => obj.Id == item.GenreId).FirstOrDefault().Name;
                    if (genre != "Без жанру") thisGenres.Add(item.GenreId, genre);
                }
            }

            foreach (var item in _context.Genres)
            {
                if ((!thisGenres.ContainsKey(item.Id)) && item.Name != "Без жанру") otherGenres.Add(item.Id, item.Name);
            }

            ViewBag.ThisGenres = thisGenres;
            ViewBag.OtherGenres = otherGenres;

            Dictionary<int, string> thisAuthors = new Dictionary<int, string>();
            Dictionary<int, string> otherAuthors = new Dictionary<int, string>();

            foreach (var item in _context.AuthorsBooks)
            {
                if (item.BookId == book.Id)
                {
                    string firstName = _context.Authors.Where(obj => obj.Id == item.AuthorId).FirstOrDefault().FirstName;
                    string lastName = _context.Authors.Where(obj => obj.Id == item.AuthorId).FirstOrDefault().LastName;
                    if (firstName != "Автор" && lastName!="Невідомий") thisAuthors.Add(item.AuthorId, firstName + " " + lastName);
                }
            }

            foreach (var item in _context.Authors)
            {
                if ((!thisAuthors.ContainsKey(item.Id)) && item.FirstName != "Автор" && item.LastName != "Невідомий") otherAuthors.Add(item.Id, item.FirstName + " " + item.LastName);
            }

            ViewBag.ThisAuthors = thisAuthors;
            ViewBag.OtherAuthors = otherAuthors;

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
                    if(genres.Length==0)
                    {
                        GenresBook gb = new GenresBook { BookId = book.Id, GenreId = _context.Genres.Where(obj => obj.Name == "Без жанру").FirstOrDefault().Id };
                        book.GenresBooks.Add(gb);
                    }
                    else
                    {
                        foreach (int GId in genres)
                        {
                            GenresBook gb = new GenresBook { GenreId = GId, BookId = book.Id };
                            book.GenresBooks.Add(gb);
                        }
                    }


                    if (authors.Length == 0)
                    {
                        AuthorsBook ab = new AuthorsBook { BookId = book.Id, AuthorId = _context.Authors.Where(obj => obj.FirstName == "Автор" && obj.LastName == "Невідомий").FirstOrDefault().Id };
                        book.AuthorsBooks.Add(ab);
                    }

                    else
                    {
                        foreach (int AId in authors)
                        {
                            AuthorsBook ab = new AuthorsBook { AuthorId = AId, BookId = book.Id };
                            book.AuthorsBooks.Add(ab);
                        }
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

            Dictionary<int, string> thisGenres = new Dictionary<int, string>();
            foreach (var item in _context.GenresBooks)
            {
                if (item.BookId == book.Id)
                {
                    string genre = _context.Genres.Where(obj => obj.Id == item.GenreId).FirstOrDefault().Name;
                    thisGenres.Add(item.GenreId, genre);
                }
            }
            ViewBag.ThisGenres = thisGenres;

            Dictionary<int, string> thisAuthors = new Dictionary<int, string>();
            foreach (var item in _context.AuthorsBooks)
            {
                if (item.BookId == book.Id)
                {
                    string firstName = _context.Authors.Where(obj => obj.Id == item.AuthorId).FirstOrDefault().FirstName;
                    string lastName = _context.Authors.Where(obj => obj.Id == item.AuthorId).FirstOrDefault().LastName;
                    thisAuthors.Add(item.AuthorId, firstName + " " + lastName);
                }
            }
            ViewBag.ThisAuthors = thisAuthors;

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
