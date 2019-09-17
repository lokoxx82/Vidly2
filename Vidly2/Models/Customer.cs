using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly.Models
{
    public class Customer
    {
        public int? Id { get; set; }

        [Display (Name = "Date of birth")]
        [Min18YearsIfAMember]
        public DateTime? BirdtDate { get; set; }

        [Required(ErrorMessage = "Type in some name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewslatter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display (Name = "Membership type")]
        public byte MembershipTypeId { get; set; }
    }
}