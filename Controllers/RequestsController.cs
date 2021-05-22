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
using LibraryApplication.Models;
using LibraryApplication.ViewModel;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryApplication.Controllers
{
    public class RequestsController : Controller
    {

        private readonly DBLibraryContext _context;

        public RequestsController(DBLibraryContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            ViewBag.Countries = _context.Countries.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            return View();
        }

        public IActionResult Request1(int country)
        {
            var result = _context.FirstRequests.FromSqlRaw("Select Distinct dbo.Books.Id, dbo.Books.Name from dbo.Books Join dbo.AuthorsBooks On dbo.Books.Id = dbo.AuthorsBooks.BookId Join dbo.Authors on dbo.Authors.Id = dbo.AuthorsBooks.AuthorId Join dbo.AuthorsCountries on dbo.Authors.Id = dbo.AuthorsCountries.AuthorId Join dbo.Countries on dbo.Countries.Id = dbo.AuthorsCountries.CountryId Where dbo.Countries.Id = {0}", country.ToString()).ToList();
            ViewBag.Result = result;
            return View();
        }

        public IActionResult Request2(int genre)
        {
            var result = _context.SecondRequests.FromSqlRaw("Select Distinct dbo.Authors.Id, dbo.Authors.FirstName, dbo.Authors.LastName from dbo.Authors Join dbo.AuthorsBooks on dbo.Authors.Id = dbo.AuthorsBooks.AuthorId Join dbo.Books on dbo.AuthorsBooks.BookId = dbo.Books.Id Join dbo.GenresBooks on dbo.GenresBooks.BookId = dbo.Books.Id Join dbo.Genres on dbo.GenresBooks.GenreId = dbo.Genres.Id Where dbo.Genres.Id = {0}", genre.ToString()).ToList();
            ViewBag.Result = result;
            return View();
        }

        public IActionResult Request3(int author)
        {
            var result = _context.FirstRequests.FromSqlRaw("Select Distinct dbo.Genres.Id, dbo.Genres.Name from dbo.Genres Join dbo.GenresBooks on dbo.Genres.Id = dbo.GenresBooks.GenreId Join dbo.Books on GenresBooks.BookId = dbo.Books.Id Join dbo.AuthorsBooks on dbo.AuthorsBooks.BookId = dbo.Books.Id join dbo.Authors on dbo.AuthorsBooks.AuthorId = dbo.Authors.Id Where dbo.Authors.Id = {0}", author.ToString()).ToList();
            ViewBag.Result = result;
            return View();
        }

        public IActionResult Request4(int genre)
        {
            var result = _context.FirstRequests.FromSqlRaw("Select Distinct dbo.Books.Id, dbo.Books.Name from dbo.Books where dbo.Books.Id Not in (Select dbo.Books.Id from dbo.Books Join dbo.GenresBooks On dbo.Books.Id = dbo.GenresBooks.BookId Join dbo.Genres on dbo.Genres.Id = dbo.GenresBooks.GenreId Where dbo.Genres.Id = {0})", genre.ToString()).ToList();
            ViewBag.Result = result;
            return View();
        }

        public IActionResult Request5(int num)
        {
            var result = _context.SecondRequests.FromSqlRaw("Select Distinct dbo.Authors.Id, dbo.Authors.FirstName, dbo.Authors.LastName from dbo.Authors Join dbo.AuthorsBooks on dbo.Authors.Id = dbo.AuthorsBooks.AuthorId Join dbo.Books on dbo.AuthorsBooks.BookId = dbo.Books.Id where dbo.Books.PagesQuantity > {0}", num.ToString()).ToList();
            ViewBag.Result = result;
            return View();
        }
    }
}
