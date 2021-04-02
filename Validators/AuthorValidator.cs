using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Validators
{
    public class AuthorValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Author a = value as Author;
            if (a.DeathYear != null && a.DeathYear < a.BirthYear) return false;
            else return true;
        }
    }
}
