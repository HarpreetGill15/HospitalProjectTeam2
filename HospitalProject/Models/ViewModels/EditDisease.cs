using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalProject.Models.ViewModels
{
    public class EditDisease
    {
        //While updating a disease two types of information are required Diseases and List of tips 

        public Diseases Diseases { get; set; }
        public List<Tips> Tips { get; set; }
    }
}