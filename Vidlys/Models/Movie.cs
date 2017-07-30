using System;
using System.ComponentModel.DataAnnotations;

namespace Vidlys.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Release { get; set; }

        [Display(Name="Number in stock")]
        public int Stock { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        public byte NumberAvailable { get; set; }
    }
}