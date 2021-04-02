using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.Models;

namespace LibraryApplication.ViewModel
{
    public class DataForFixedBar
    {
        
        private static readonly DBLibraryContext _context = new DBLibraryContext();
    public static List<Country> Countries {
        get
        {
            return _context.Countries.ToList();
        } }
    public static List<Genre> Genres
    {
        get
        {
            return _context.Genres.ToList();
        }
    }
    }
    }
