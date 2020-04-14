using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//the namespace for dbcontext
using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.Models.ViewModels;

namespace HospitalProject.Controllers
{
    public class DonationsController : Controller
    {
        //to define this line, we need a namespace
        private HospitalContext db = new HospitalContext();
        // GET: Donations
        //expected to see the list of all donations
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult List()
        {
            return View();
        }
        //Get the Add page: this only shows the Add page
        //with populated provinces and designations from other tables
        public ActionResult Add()
        {
            //to use the dbcontext we need to define it at the top of the controller
            //dbsets have been already added to the dbcontext file
            //we need a viewModel because this is a list from another table
            var provinces = db.Provinces.ToList();
            var designations = db.Designations.ToList();

            //initialize the viewmodel
            var viewModel = new NewDonationViewModel
            {
                Provinces =  provinces,
                Designations = designations
            };
            //pass the viewModel to the view 
            return View(viewModel);
        }

        //A Post method to submit the form of donation
        [HttpPost]
        //Model binding to the request data
        public ActionResult Add(Donation donation)
        {
            //add the donation to the dbcontext
            db.Donations.Add(donation);
            //to save the changes in the actual db
            db.SaveChanges();
            //redirect to the home page
            return RedirectToAction("Index", "Home");
        }
    }
}