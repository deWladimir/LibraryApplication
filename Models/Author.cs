using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LibraryApplication
{
    public partial class Author
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorsBook>();
            AuthorsCountries = new HashSet<AuthorsCountry>();
        }

        public int Id { get; set; }
        [Display(Name ="Ім’я")]
        [Required(ErrorMessage = "Ім’я не може бути порожнім")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Прізвище")]
        [Required(ErrorMessage = "Прізвище не може бути порожнім")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Інформація")]
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Info { get; set; }

        [Display(Name ="Рік народження")]
        [Required(ErrorMessage ="Поле не може бути порожнім")]
        [Range(1,2021)]
        public int BirthYear { get; set; }

        [Display(Name = "Рік смерті")]
        [Range(1,2021)]
        public int? DeathYear { get; set; }

        public virtual ICollection<AuthorsBook> AuthorsBooks { get; set; }
        public virtual ICollection<AuthorsCountry> AuthorsCountries { get; set; }
    }
}
