using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidlys.Models;

namespace Vidlys.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a valid name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSuscribedToNewsLetter { get; set; }

 
        public byte MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}