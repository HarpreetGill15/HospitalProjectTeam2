using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        //One to many relationship in: one designation can include many donations
        public ICollection<Donation> Donations { get; set; }

    }
}