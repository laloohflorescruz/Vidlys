using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidlys.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Release { get; set; }
        public int Stock { get; set; }

    }
}