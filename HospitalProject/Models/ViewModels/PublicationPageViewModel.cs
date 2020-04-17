using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalProject.Models.ViewModels
{
    public class PublicationPageViewModel
    {
        public PublicationViewModel Publication { get; set; }
        public IList<PublicationShortViewModel> Children { get; set; }
        public bool IsEditable { get; set; }
    }
}