using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject.Models
{
    public class Tips
    {
        //Tip for a particular disease can be described with TipID,TipName,Date 
        [Key]

        public int TipID { get; set; }
        public string TipName { get; set; }
        public DateTime Date { get; set; }

        // As one one disease can have many tips 
        // So reperesenting one disease with many tips
        public int DiseaseID { get; set; }
        [ForeignKey("DiseaseID")]
        public virtual Diseases Diseases { get; set; }
    }
}