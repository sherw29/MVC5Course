using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<MovieGenre> Genres { get; set; }
    }
}