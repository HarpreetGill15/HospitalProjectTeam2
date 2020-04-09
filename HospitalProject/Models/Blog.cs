using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImagePath { get; set; }
    }
}