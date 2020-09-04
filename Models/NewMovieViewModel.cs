using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<MovieGenre> MovieGenres { get; set; }
    }
}