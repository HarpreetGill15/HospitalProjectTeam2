using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalProject.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() : base("name=HospitalContext")
        {

        }
        public System.Data.Entity.DbSet<HospitalProject.Models.Notifications> Notifications { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.NotificationTypes> NotificationTypes { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Feedbacks> Feedbacks { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.FeedbackTypes> FeedbackTypes { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Departments> Departments { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Blog> Blogs { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Donor> Donors { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Donation> Donations { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Job> Jobs { get; set; }

    }
}