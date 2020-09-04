using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DoB { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        public string Address { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }


        [Required(ErrorMessage = "Please Select a membership type")]
        public byte MembershipTypeId { get; set; }
    }
}