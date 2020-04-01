using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    public class News
    {
        //The class news contains information such as:
        //id, headline, content, publish date and an image path for the relevant picture
        [Key]
        public int NewsId { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; } 
        public string ImagePath { get; set; }
    }
}