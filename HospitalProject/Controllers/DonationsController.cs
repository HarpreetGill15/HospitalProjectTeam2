using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.EntitySql;
using System.Diagnostics;
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
        //expected to see the list of all donations on the index page
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult List()
        {
            //we use include method here because we want designation to be shown at the same time
            //as the donation details: Eager Loading: https://docs.microsoft.com/en-us/ef/ef6/querying/related-data
            List<Donation> donations = db.Donations.Include(d => d.Designation).ToList();
            return View(donations);
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

        //Get request: url -> Donations/Show/1
        public ActionResult Show(int id)
        {
            //get the specified donation
            var donation = db.Donations.Include(d => d.Designation).Include(d => d.Province).SingleOrDefault(d => d.Id == id);
            return View(donation);
        }

        //Get request for the confirmation page
        public ActionResult ConfirmDelete(int id)
        {
            Donation donation = db.Donations.Find(id);
            return View(donation);
        }

        //post request to delete the record for donation
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Donation donation = db.Donations.Find();
            //remove from the dbcontext
            db.Donations.Remove(donation);
            //delete from the actual database
            db.SaveChanges();
            return RedirectToAction("List");
        }

        //Get request to get the page of the selected donation
        //URL: Donations/Update/1
        public ActionResult Update(int id)
        {
            //find the donation in the db
            var donation = db.Donations.SingleOrDefault(d => d.Id == id);
            //set the viewModel for the update page: Display foreign keys(Provinces , Designations)
            var viewModel = new NewDonationViewModel
            {
                Donation = donation,
                Designations = db.Designations.ToList(),
                Provinces = db.Provinces.ToList()
            };
            //display the update donation page
            return View("Update", viewModel);
        }
        //Post request for the update action
        [HttpPost]
        public ActionResult Update(Donation donation)
        {
            var selectedDonation = db.Donations.Single(d=> d.Id == donation.Id);

            selectedDonation.Amount = donation.Amount;
            selectedDonation.FirstName = donation.FirstName;
            selectedDonation.LastName = donation.LastName;
            selectedDonation.Email = donation.Email;
            selectedDonation.Phone = donation.Phone;
            selectedDonation.City = donation.City;
            selectedDonation.ZipCode = donation.ZipCode;
            selectedDonation.DesignationId = donation.DesignationId;
            selectedDonation.ProvinceId = donation.ProvinceId;
            //change the db
            db.SaveChanges();
            return RedirectToAction("Show");
        }



    }
}