using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApplication;
using Microsoft.AspNetCore.Authorization;

namespace LibraryApplication.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly DBLibraryContext _context;

        public AuthorsController(DBLibraryContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "admin, user")]
        // GET: Authors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authors.ToListAsync());
        }

        [Authorize(Roles = "admin, user")]
        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewBag.ThisCountries = _context.AuthorsCountries.Where(obj => obj.AuthorId == id).Join(_context.Countries, a => a.CountryId, c => c.Id, (a, c) => new
            {
                Id = a.CountryId,
                Name = c.Name
            });

            ViewBag.ThisBooks = _context.AuthorsBooks.Where(obj => obj.AuthorId == id).Join(_context.Books, a => a.BookId, b => b.Id, (a, b) => new
            {
                Id = b.Id,
                Name = b.Name
            });

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [Authorize(Roles = "admin")]

        // GET: Authors/Create
        public IActionResult Create()
        {
            ViewBag.CountriesList = _context.Countries.ToList();
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Info,BirthYear,DeathYear")] Author author, List<int> countries)
        {
            var IsRepeat = _context.Authors.Where(obj => obj.FirstName == author.FirstName && obj.LastName == author.LastName && obj.BirthYear == author.BirthYear);
            foreach(var item in IsRepeat)
            {
                bool flag = false;
                var IsRepeatCountries = thisAuthorCountries(item.Id);
                foreach (var c in countries)
                {
                    if (IsRepeatCountries.Where(obj=>obj.CountryId==c).Count()>0) {
                        flag = true;
                        break;
                    }
                }
                if(flag) ModelState.AddModelError("","Такий автор вже існує");
            }

            

            if (ModelState.IsValid)
            {
                
                _context.Add(author);

                foreach (var cID in countries)
                {
                    AuthorsCountry ac = new AuthorsCountry { AuthorId = author.Id, CountryId = cID };
                    author.AuthorsCountries.Add(ac);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CountriesList = _context.Countries.ToList();
            return View();
        }
        [Authorize(Roles = "admin")]
        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);

            var thisC = _context.AuthorsCountries.Where(obj => obj.AuthorId == id).Join(_context.Countries, a => a.CountryId, c => c.Id, (a, c) => new
            {
                Id = a.CountryId,
                Name = c.Name
            });

            List<string> CNames = new List<string>();
            foreach (var tC in thisC) CNames.Add(tC.Name);

            ViewBag.OtherCountries = _context.Countries.Where(obj => !CNames.Contains(obj.Name)).ToList();
          
            ViewBag.ThisCountries = thisC;

            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [Authorize(Roles = "admin")]
        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Info,BirthYear,DeathYear")] Author author, int[] countries)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            var IsRepeat = _context.Authors.Where(obj => obj.Id != author.Id && obj.FirstName == author.FirstName && obj.LastName == author.LastName && obj.BirthYear == author.BirthYear);
            foreach (var item in IsRepeat)
            {
                bool flag = false;
                var IsRepeatCountries = thisAuthorCountries(item.Id);
                foreach (var c in countries)
                {
                    if (IsRepeatCountries.Where(obj => obj.CountryId == c).Count() > 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    ModelState.AddModelError("", "Такий автор вже існує");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    var authorsCountries = thisAuthorCountries(id);
                    foreach (var item in authorsCountries)
                    {
                            _context.AuthorsCountries.Remove(item);
                    }
                 
                    {
                        foreach (var cID in countries)
                        {
                            AuthorsCountry ac = new AuthorsCountry { AuthorId = author.Id, CountryId = cID };
                            author.AuthorsCountries.Add(ac);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.Id))
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

            var thisC = _context.AuthorsCountries.Where(obj => obj.AuthorId == id).Join(_context.Countries, a => a.CountryId, c => c.Id, (a, c) => new
            {
                Id = a.CountryId,
                Name = c.Name
            });

            List<string> CNames = new List<string>();
            foreach (var tC in thisC) CNames.Add(tC.Name);

            ViewBag.OtherCountries = _context.Countries.Where(obj => !CNames.Contains(obj.Name)).ToList();

            ViewBag.ThisCountries = thisC;

            return View(author);
        }

        [Authorize(Roles = "admin")]

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            
            ViewBag.CNames = _context.AuthorsCountries.Where(obj => obj.AuthorId == id).Join(_context.Countries, a => a.CountryId, c => c.Id, (a, c) => new
            {
                Name = c.Name
            });

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
        [Authorize(Roles = "admin")]
        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            var authorsCountries = thisAuthorCountries(author.Id);
            foreach (var item in authorsCountries)
            {
                _context.AuthorsCountries.Remove(item);
            }
            var authorsBooks = _context.AuthorsBooks.Where(obj => obj.AuthorId == id);
            foreach (var item in authorsBooks)
            {
                var genresBooks = _context.GenresBooks.Where(obj => obj.BookId == item.BookId);
                foreach (var gb in genresBooks)
                {         
                    _context.GenresBooks.Remove(gb);
                }
                var book = _context.Books.Where(obj => obj.Id == item.BookId).FirstOrDefault();
                _context.AuthorsBooks.Remove(item);
                _context.Books.Remove(book);
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }

        IQueryable<AuthorsCountry> thisAuthorCountries(int id)
        {
            return _context.AuthorsCountries.Where(obj=>obj.AuthorId==id);
        }

    }
}
