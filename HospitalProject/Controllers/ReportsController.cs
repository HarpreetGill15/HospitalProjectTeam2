using HospitalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using HospitalProject.Data;
using HospitalProject.Models.ViewModels;

namespace HospitalProject.Controllers
{
    public class ReportsController : Controller
    {
        public ActionResult Create()
        {
                if (!IsCurrentUserAdmin())
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
                }

                return View();
            
        }

        public ReportsController()
        {
            ViewBag.IsPublicReporting = true;
        }

        /// <summary>
        /// Return if current user is administrator
        /// </summary>
        public bool IsCurrentUserAdmin()
        {
            using (var db = new ApplicationDbContext())
            {
                string userId = User.Identity.GetUserId();
                return db.Roles.Any(x => x.Name == "Administrator" && x.Users.Any(y => y.UserId == userId));
            }
        }
        // GET: Reports
        public ActionResult Index()
        {
            var model = new ReportingPageViewModel();
            using (var db = new HospitalContext())
            {

                // administrators are allowed to edit information
                model.IsEditable = IsCurrentUserAdmin();

                model.Reports = db.Reports.Select(
                    x => new ReportViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description
                    }).
                    ToList();

            }

            return View(model);
        }
    }
}