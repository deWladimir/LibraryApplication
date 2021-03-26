using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApplication
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public DateTime DateTime { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
