using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Validators
{
    public class GenreValidator : ValidationAttribute
    {
        private readonly DBLibraryContext _context = new DBLibraryContext();
        public override bool IsValid(object value)
        {
            Genre g = value as Genre;
            var areRepeats = _context.Genres.Where(obj => obj.Name == g.Name && obj.Id!=g.Id);
            if (areRepeats.Count() > 0) return false;
            else return true;
        }
    }
}
