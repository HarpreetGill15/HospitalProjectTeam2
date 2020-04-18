using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject.Models
{
    public class PatientsRegistration
    {
        // A patient can be registered with following details
        //Firstname,Lastname,Email,Address,City,PostalCode,Gender,PhoneNumber,DOB,Emergency Contact Name,Emergency Number
        [Key]
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string postalcode { get; set; }
        public string gender { get; set; }
        public int phone { get; set; }
        public string dob { get; set; }
        public string emergencycontactname { get; set; }
        public int emergencycontactnumber { get; set; }


    }
}