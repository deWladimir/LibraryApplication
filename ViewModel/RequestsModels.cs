using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.ViewModel
{
    [Keyless]
    public class FirstRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Keyless]
    public class SecondRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

}
