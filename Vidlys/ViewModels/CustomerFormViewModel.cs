using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidlys.Models;

namespace Vidlys.ViewModels
{
    public class CustomerFormViewModel
    {
        //public Movie Movie { get; set; }

        public IEnumerable<MembershipType> MembershipType { get; set; }

        public Customer Customer { get; set; }
    }
}