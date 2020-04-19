using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject.Controllers
{

    public class PublicationsController : Controller
    {

        public PublicationsController()
        {
            ViewBag.IsPublications = true;
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

        

        //Publications classes:

        /// <summary>
        /// Creates new publication 
        /// </summary>
        [HttpGet]
        public ActionResult Create(int? id)
        {
            using (var db = new HospitalContext())
            {
                if (!IsCurrentUserAdmin())
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
                }

                PublicationViewModel publication = new PublicationViewModel
                {
                    Id = id ?? 0
                };

                return View(publication);
            }
        }

        /// <summary>
        /// Creates new publication
        /// </summary>
        [HttpPost]
        public ActionResult Create(PublicationViewModel model)
        {
            using (var db = new HospitalContext())
            {
                if (!IsCurrentUserAdmin())
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
                }

                var publication = new Publication();
                publication.Title = model.Title;
                publication.Body = model.Body;
                publication.ParentId = (model.Id == 0 ? (int?)null : model.Id);
                db.Publications.Add(publication);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = publication.Id });
            }
        }


        /// <summary>
        /// Delete publication
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

                var publication = db.Publications.FirstOrDefault(x => x.Id == id);
                if (publication == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }

                db.Publications.Remove(publication);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = publication.ParentId });
            }
        }
        /// <summary>
        /// Save publication
        /// </summary>
        [HttpPost]
        public ActionResult Edit(PublicationViewModel model)
        {
            using (var db = new HospitalContext())
            {
                if (!IsCurrentUserAdmin())
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
                }

                var publication = db.Publications.FirstOrDefault(x => x.Id == model.Id);
                if (publication == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }

                publication.Title = model.Title;
                publication.Body = model.Body;
                db.SaveChanges();
            }

            return RedirectToAction("Index", new { id = model.Id });
        }

        /// <summary>
        /// Edit publication
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

                PublicationViewModel publication = db.Publications.
                        Where(x => x.Id == id).
                        Select(x => new PublicationViewModel
                        {
                            Id = x.Id,
                            Body = x.Body,
                            ParentId = x.ParentId,
                            Title = x.Title,
                            TitleImage = x.TitleImage
                        }).FirstOrDefault();

                if (publication == null)
                {
                    // if publication is not found 
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }

                return View(publication);
            }
        }

        /// <summary>
        /// Show publication
        /// </summary>
        public ActionResult Index(int? id)
        {
            var model = new PublicationPageViewModel();
            using (var db = new HospitalContext())
            {

                // administrators are allowed to edit information
                model.IsEditable = IsCurrentUserAdmin();

                if (id != null)
                {
                    // get current publication detailed info
                    // for instance: 
                    //   "Root" page has no info at all (id == null), we will not get here
                    //   "No Visitor policy" has id and body (visitors are currently restricted...) 
                    model.Publication = db.Publications.
                        Where(x => x.Id == id).
                        Select(x => new PublicationViewModel
                        {
                            Id = x.Id,
                            Body = x.Body,
                            ParentId = x.ParentId,
                            Title = x.Title,
                            TitleImage = x.TitleImage
                        }).First();
                }

                // get all nested publications.
                // for instance: 
                //   root page has children: Patients, Visitors
                //   "Patients" page has children: No Visitor Policy,  Safe Care, What to bring
                model.Children = db.Publications.
                        Where(x => x.ParentId == id).
                        Select(x => new PublicationShortViewModel
                        {
                            Id = x.Id,
                            Title = x.Title,
                            TitleImage = x.TitleImage
                        }).ToList();
            }

            return View(model);
        }

    }
}