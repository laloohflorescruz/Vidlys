using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidlys.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public DateTime Release { get; set; }

        public int Stock { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDTO Genre { get; set; }

        [Range(1,20)]
        public int NumberInStock { get; set; }

    }
}