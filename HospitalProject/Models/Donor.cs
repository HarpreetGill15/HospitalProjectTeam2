using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    public class Donor
    {
        //information about a donor:
        //primary key in the db
        [Key]
        public int DonorId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        //postal code
        public string PCode { get; set; }
        //One donor can have many donations:
        public ICollection<Donation> Donations { get; set; }

    }
}