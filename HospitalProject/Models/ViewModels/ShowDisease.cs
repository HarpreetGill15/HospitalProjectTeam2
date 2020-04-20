using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalProject.Models.ViewModels
{
    public class ShowDisease
    {
       //following line of code lists detail about one disease
        public virtual Diseases Diseases { get; set; }
    }
}