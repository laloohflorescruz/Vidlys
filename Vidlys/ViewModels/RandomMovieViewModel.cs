using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidlys.Models;

namespace Vidlys.ViewModels
{
    public class RandomMovieViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
 
        public Movie Movie { get; set; }

        public int? Id { get; set; }

        public RandomMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Release = movie.Release;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
            
        }

        public string Name { get; set; }

        public int? GenreId { get; set; }

        public DateTime Release { get; set; }

        public int Stock { get; set; }

        public RandomMovieViewModel()
        {
            Id = 0;
        }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}