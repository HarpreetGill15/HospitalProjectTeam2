using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject.Models
{
    public class Diseases
    {
        //Tips and Advices for diseases can be defined with
        //TipName,DiseaseName,Content for descriptipon 
        //Tips are reperesented in Tips Class
        [Key]
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public string Content { get; set; }

        //one disease can have many tips 

        //so reperesenting one disease with many tips

        public ICollection<Tips> Tips { get; set; }

    }
}