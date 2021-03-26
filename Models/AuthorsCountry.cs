using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApplication
{
    public partial class AuthorsCountry
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int CountryId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Country Country { get; set; }
    }
}
