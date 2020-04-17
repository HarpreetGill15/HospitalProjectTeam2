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
        /// <summary>
        /// Table for reports (Annual Reports, By-Laws, ... )
        /// </summary>
        public DbSet<HospitalProject.Models.Report> Reports { get; set; }

        /// <summary>
        /// Table for publications (patients, visitors, ...) 
        /// </summary>
        public DbSet<HospitalProject.Models.Publication> Publications { get; set; }

        /// <summary>
        /// Table for files that are connected to reports (for instance: "General By-Law, March 2019" for report "By-Laws")
        /// </summary>
        public DbSet<HospitalProject.Models.ReportFile> ReportFiles { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Notifications> Notifications { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.NotificationTypes> NotificationTypes { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Feedbacks> Feedbacks { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.FeedbackTypes> FeedbackTypes { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Departments> Departments { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Blog> Blogs { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Designation> Designations { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Donation> Donations { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Province> Provinces { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Job> Jobs { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.Application> Applications { get; set; }
        public System.Data.Entity.DbSet<HospitalProject.Models.FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }
    }
}