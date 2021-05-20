using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;



namespace LibraryApplication.Controllers
{
    [Authorize(Roles = "admin, user")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly DBLibraryContext _context;

        public ChartsController(DBLibraryContext context)
        {
            _context = context;
        }

        [HttpGet("GenresData")]
        public JsonResult GenresData()
        {
            var booksTocategories = _context.Genres.ToList();

            List<object> genreBooks = new List<object>();
            genreBooks.Add(new object[] { "Жанр", "Кількість книжок" });
            foreach (var data in booksTocategories)
            {
                int quantity = _context.GenresBooks.Where(obj => obj.GenreId == data.Id).Count();
                if (quantity > 0)
                {
                    genreBooks.Add(new object[] { data.Name, quantity });
                }
                else genreBooks.Add(new object[] { data.Name, 0 });
            }

            return new JsonResult(genreBooks);
        }

        [HttpGet("AuthorsData")]
        public JsonResult AuthorsData()
        {
            var authorsTocategories = _context.Authors.ToList();

            List<object> authorBooks = new List<object>();
            authorBooks.Add(new object[] { "Автор", "Кількість книжок" });
            foreach (var data in authorsTocategories)
            {
                int quantity = _context.AuthorsBooks.Where(obj => obj.AuthorId == data.Id).Count();
                if (quantity > 0)
                {
                    authorBooks.Add(new object[] { data.FirstName + " " + data.LastName, quantity });
                }
                else authorBooks.Add(new object[] { data.FirstName + " " + data.LastName, 0 });
            }

            return new JsonResult(authorBooks);
        }
    }
}
