using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibraryApplication.Validators;

#nullable disable
namespace LibraryApplication
{
    [GenreValidator(ErrorMessage = "Такий жанр вже існує")]
    public partial class Genre
    {
        public Genre()
        {
            GenresBooks = new HashSet<GenresBook>();
        }

        public int Id { get; set; }

        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Назва не може бути порожньою")]
        public string Name { get; set; }
        [Display(Name = "Інформація")]
        public string Info { get; set; }

        public virtual ICollection<GenresBook> GenresBooks { get; set; }
    }
}
