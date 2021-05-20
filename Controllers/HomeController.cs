using LibraryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
namespace LibraryApplication.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBLibraryContext _context;

        public HomeController(ILogger<HomeController> logger, DBLibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Books = _context.Books.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Countries = _context.Countries.ToList();
            return View();
        }

        public IActionResult CountryFilter(int id)
        {
            ViewBag.Country = _context.Countries.Where(obj => obj.Id == id).FirstOrDefault().Name;
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Countries = _context.Countries.ToList();

            Dictionary<int, string> thisAuthors = new Dictionary<int, string>();
            var authorsCountries = _context.AuthorsCountries.Where(obj => obj.CountryId == id);
            foreach (var c in authorsCountries)
            {
                var author = _context.Authors.Where(obj => obj.Id == c.AuthorId).FirstOrDefault();
                string fullName = author.FirstName + " " + author.LastName;
                thisAuthors.Add(c.AuthorId, fullName);
            }
            ViewBag.ThisAuthors = thisAuthors;
            return View();
        }

        public IActionResult GenreFilter(int id)
        {
            ViewBag.Genre = _context.Genres.Where(obj => obj.Id == id).FirstOrDefault().Name;
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Countries = _context.Countries.ToList();

            Dictionary<int, string> thisBooks = new Dictionary<int, string>();
            var genresBooks = _context.GenresBooks.Where(obj => obj.GenreId == id);
            foreach (var g in genresBooks)
            {
                thisBooks.Add(g.BookId, _context.Books.Where(obj => obj.Id == g.BookId).FirstOrDefault().Name);
            }
            ViewBag.ThisBooks = thisBooks;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        [HttpPost]
        public IActionResult Search(string query)
        {
            List<Author> authors = _context.Authors.Where(obj => (obj.FirstName + " " + obj.LastName).Contains(query)).ToList();
            List<Book> books = _context.Books.Where(obj => obj.Name.Contains(query)).ToList();
            ViewBag.Authors = authors;
            ViewBag.Books = books;
            ViewBag.BNumber = books.Count();
            ViewBag.ANumber = authors.Count();
            ViewBag.Query = query;
            return View();
        }
    }
}
