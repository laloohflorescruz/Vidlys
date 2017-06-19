using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidlys.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a valid name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSuscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }

    }
}