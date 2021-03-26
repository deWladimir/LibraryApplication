using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApplication;

namespace LibraryApplication.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly DBLibraryContext _context;

        public AuthorsController(DBLibraryContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authors.ToListAsync());
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            Dictionary<int, string> thisCountries = new Dictionary<int, string>();
            var authorsCountries = _context.AuthorsCountries.Where(obj => obj.AuthorId == author.Id);
            foreach (var item in authorsCountries)
            {
                thisCountries.Add(item.CountryId, _context.Countries.Where(obj => obj.Id == item.CountryId).FirstOrDefault().Name);
            }
            ViewBag.ThisCountries = thisCountries;

            Dictionary<int, string> thisBooks = new Dictionary<int, string>();
            var authorsBooks = _context.AuthorsBooks.Where(obj => obj.AuthorId == author.Id);
            foreach (var item in authorsBooks)
            {
                thisBooks.Add(item.BookId, _context.Books.Where(obj => obj.Id == item.BookId).FirstOrDefault().Name);
            }
            ViewBag.ThisBooks = thisBooks;
            if (author == null)
            {
                return NotFound();
            }

            //if (CId.Count == 0) return RedirectToAction(nameof(Index));

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            ViewBag.CountriesList = _context.Countries.Where(obj=> obj.Name != "Інтернаціональ").ToList();
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Info,BirthYear,DeathYear")] Author author, int[] countries)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(author);
                if (countries.Length == 0) 
                {
                    AuthorsCountry ac = new AuthorsCountry { AuthorId = author.Id, CountryId = _context.Countries.Where(obj=>obj.Name == "Інтернаціональ").FirstOrDefault().Id };
                    author.AuthorsCountries.Add(ac);
                }
                foreach (var cID in countries)
                {
                    AuthorsCountry ac = new AuthorsCountry { AuthorId = author.Id, CountryId = cID };
                    author.AuthorsCountries.Add(ac);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);
            Dictionary<int, string> countries = new Dictionary<int, string>();
            Dictionary<int, string> otherCountries =  new Dictionary<int, string>();
            foreach (var item in _context.AuthorsCountries)
            {
                if (item.AuthorId == id)
                {
                    string name = _context.Countries.Where(obj => obj.Id == item.CountryId).FirstOrDefault().Name;
                    if (name != "Інтернаціональ")
                    {
                        countries.Add(item.CountryId, name);
                    }
                }
            }

            ViewBag.Countries = countries;
            foreach (var item in _context.Countries)
            {
                if ((!countries.ContainsKey(item.Id)) && item.Name!="Інтернаціональ" ) otherCountries.Add(item.Id, item.Name);
            }

            ViewBag.OtherCountries = otherCountries;

            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

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

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    foreach (var item in _context.AuthorsCountries)
                    {
                        if (item.AuthorId == author.Id)
                        {
                            _context.AuthorsCountries.Remove(item);
                        }
                    }
                    if (countries.Length == 0)
                    {
                        AuthorsCountry ac = new AuthorsCountry { AuthorId = author.Id, CountryId = _context.Countries.Where(obj => obj.Name == "Інтернаціональ").FirstOrDefault().Id };
                        author.AuthorsCountries.Add(ac);
                    }
                    else
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
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            List<string> CNames = new List<string>();
            foreach (var item in _context.AuthorsCountries)
            {
                if (item.AuthorId == id)
                {
                    var obj = _context.Countries.Where(obj => obj.Id == item.CountryId).FirstOrDefault().Name;
                    CNames.Add(obj);
                }
            }
            ViewBag.CNames = CNames;

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            foreach (var item in _context.AuthorsCountries)
            {
                if (item.AuthorId == author.Id)
                {
                    _context.AuthorsCountries.Remove(item);
                }
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
