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
    //Reports classes:
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

        /// <summary>
        /// Creates new report
        /// </summary>
        [HttpPost]
        public ActionResult Create(ReportViewModel model)
        {
            using (var db = new HospitalContext())
            {
                if (!IsCurrentUserAdmin())
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
                }

                var report = new Report();
                report.Title = model.Title;
                report.Description = model.Description;
                db.Reports.Add(report);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Delete Report
        /// </summary>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new HospitalContext())
            {
                if (!IsCurrentUserAdmin())
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
                }

                var report = db.Reports.FirstOrDefault(x => x.Id == id);
                if (report == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }

                db.Reports.Remove(report);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Save report
        /// </summary>
        [HttpPost]
        public ActionResult Edit(ReportViewModel model)
        {
            using (var db = new HospitalContext())
            {
                if (!IsCurrentUserAdmin())
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
                }

                var report = db.Reports.FirstOrDefault(x => x.Id == model.Id);
                if (report == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }

                report.Title = model.Title;
                report.Description = model.Description;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edit report
        /// </summary>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            using (var db = new HospitalContext())
            {
                // if user is not admin --> get error ! 
                if (!IsCurrentUserAdmin())
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
                }

                ReportViewModel report = db.Reports.
                        Where(x => x.Id == id).
                        Select(x => new ReportViewModel
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Description = x.Description
                        }).FirstOrDefault();

                if (report == null)
                {
                    // if report is not found 
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }

                return View(report);
            }
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



} //Closing Namespace