using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibraryApplication.Validators;

#nullable disable

namespace LibraryApplication
{
    [BookValidator(ErrorMessage ="Така книжка вже існує")]
    public partial class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorsBook>();
            Comments = new HashSet<Comment>();
            GenresBooks = new HashSet<GenresBook>();
        }

        public int Id { get; set; }
        [Display(Name = "Назва книги")]
        [Required(ErrorMessage = "Назва не може бути порожньою")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Анотація")]
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        public string Info { get; set; }
        [Display(Name = "Шлях до fb2 файлу")]
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [RegularExpression(@"^(/css/fb2Books/)\S+.fb2$", ErrorMessage = "Формат  /css/fb2Books/ім’я_файлу.fb2")]
        public string Fb2 { get; set; }
        [Display(Name = "Шлях до pdf файлу")]
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [RegularExpression(@"^(/css/pdfBooks/)\S+.pdf$", ErrorMessage = "Формат  /css/pdfBooks/ім’я_файлу.pdf")]
        public string Pdf { get; set; }
        [Display(Name = "Кількість сторінок")]
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Range(1,3000)]
        public int PagesQuantity { get; set; }
        [Display(Name = "Шлях до обкладинки")]
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [RegularExpression(@"^(/css/covers/)\S+.(png|jpeg|jpg)$", ErrorMessage = "Формат  /css/covers/ім’я_файлу.jpeg|png|jpg")]
        public string Picture { get; set; }

        public virtual ICollection<AuthorsBook> AuthorsBooks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<GenresBook> GenresBooks { get; set; }
    }
}
