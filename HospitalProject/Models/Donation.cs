using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    public class Donation
    {
        //donations information:
        //id, amount of money as donation, donor id -> who has done it
        [Key]
        public int DonationId { get; set; }
        //the unit for this amount is CENTS
        public int Amount { get; set; }
        //foreign key (representing the one to many relationship: One Donor to many Donations
        public int DonorId { get; set; }
        [ForeignKey("DonorId")]
        public virtual Donor Donor { get; set; }
    }
}