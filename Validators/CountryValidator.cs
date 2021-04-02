using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Validators
{
    public class CountryValidator : ValidationAttribute
    {
        private readonly DBLibraryContext _context = new DBLibraryContext();
        public override bool IsValid(object value)
        {
            Country c = value as Country;
            var areRepeats = _context.Countries.Where(obj => obj.Name == c.Name && obj.Id!=c.Id);
            if (areRepeats.Count() > 0) return false;
            else return true;
        }
    }
}
