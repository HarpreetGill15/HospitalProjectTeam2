using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    public class Publication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleImage { get; set; }
        public string Body { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Publication ParentPublication { get; set; }
    }
}