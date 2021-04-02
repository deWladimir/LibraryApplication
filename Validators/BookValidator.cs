using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Validators
{
    public class BookValidator : ValidationAttribute
    {
        DBLibraryContext _context = new DBLibraryContext();

        public override bool IsValid(object value)
        {
            Book b = value as Book;
            var areRepeats = _context.Books.Where(obj => obj.Id != b.Id && ( obj.Fb2 == b.Fb2 || obj.Pdf == b.Pdf || obj.Picture==b.Picture));
            if (areRepeats.Count() > 0) return false;
            else return true;
        }
    }
}
