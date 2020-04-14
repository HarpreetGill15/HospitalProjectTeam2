using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string Initials { get; set; }
        //This line should be here to show the one to many relationship: One province can include many donations
        public ICollection<Donation> Donations { get; set; }

    }
}