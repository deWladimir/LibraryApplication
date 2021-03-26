using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibraryApplication
{
    public partial class Country
    {
        public Country()
        {
            AuthorsCountries = new HashSet<AuthorsCountry>();
        }

        public int Id { get; set; }

        [Display(Name="Країна")]
        [Required(ErrorMessage = "Назва не може бути порожньою")]
        public string Name { get; set; }

        public virtual ICollection<AuthorsCountry> AuthorsCountries { get; set; }
    }
}
