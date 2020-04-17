using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalProject.Models.ViewModels
{
    public class PublicationViewModel : PublicationShortViewModel
    {
        public int? ParentId { get; set; }
        public string Body { get; set; }
    }
}