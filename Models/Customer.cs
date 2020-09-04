using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Date of Birth")]
        public DateTime DoB { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Email Id")]
        public string EmailId { get; set; }

        public string Address { get; set; }

        [Display(Name="News Letter Subscription")]
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage ="Please Select a membership type")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}