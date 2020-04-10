
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HospitalProject.Data;
using HospitalProject.Models;

namespace HospitalProject.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            return View();
        }

        //Creating a db object of the Hospital Context file. 
        private HospitalContext db = new HospitalContext();

        public ActionResult JobList(string searchKey)
        {
            Debug.WriteLine("Entered ListJobs..");
            Debug.WriteLine("Entered Search key is" + searchKey);

            string query = "select * from jobs";

            if(searchKey!=null)
            {
                query = query + "where name like '%" + searchKey + "%'";

            }
            List<Job> jobs = db.Jobs.SqlQuery(query).ToList();

            return View(jobs);
        }


        // GET: Function is used to call the view that will display the Add form
        public ActionResult AddJob()
        {
            Debug.WriteLine("Adding new Jobs...");
            return View();
        }

        //POST: Method to get the values from the  admin
        [HttpPost]
        public ActionResult AddJob(string name, string skill, string description, string type, string salary)
        {
            Debug.WriteLine("Adding a new job");
            Debug.WriteLine(name + description + skill + description + type + salary);

            //Query to create a new Job Post
            string query = "insert into Jobs (name,skill,description,type,salary) values (@name,@skill,@description,@type,@salary)";
            SqlParameter[] sqlParams = new SqlParameter[5];
            sqlParams[0] = new SqlParameter("@name", name);
            sqlParams[1] = new SqlParameter("@skill", skill);
            sqlParams[2] = new SqlParameter("@description", description);
            sqlParams[3] = new SqlParameter("@type", type);
            sqlParams[4] = new SqlParameter("@salary", salary);
            db.Database.ExecuteSqlCommand(query, sqlParams);

            //Redirecting the control back to list jobs. 
            return RedirectToAction("JobList");
        }

        //GET: Function to get the specific Job details. 
        public ActionResult ShowJob(int id)
        {
            Debug.WriteLine("Entering Show Job");
            Debug.WriteLine("Entered Job ID is:" + id);

            //This query gets the job with the specified jobId
            string query = "select * from Jobs where JobId = @JobId";
            Job job = db.Jobs.SqlQuery(query, new SqlParameter("@JobId", id)).FirstOrDefault();


            //Returning the ShowJobPost ViewModel object to the ShowJob view. 
            return View(job);


        }


        //GET: This function is used to fetch the data that will be displayed in the update function. 
        public ActionResult UpdateJob(int id)
        {
            Debug.WriteLine("Entering Update Job");
            Debug.WriteLine("Fetching data to be displayed in the update job page");

            //Query to get the job Details with specific jobId id. 
            string query = "select * from Jobs where JobId = @jobId";
            Job job = db.Jobs.SqlQuery(query, new SqlParameter("@jobId", id)).FirstOrDefault();

            //Calling the job view with the Specific job details
            return View(job);
        }

        //POST: This function is used to Update the Job table with the data entered in the update page form. 
        [HttpPost]
        public ActionResult UpdateJob(int? id, string name, string skill, string description, string type, int salary)
        {
            Debug.WriteLine("Updating job " + id);
            Debug.WriteLine("Updating the data entered in the form to the Job table ");

            //Query to update the job details into the Job table
            string query = "update Jobs set name = @name, skill = @skill,description = @description,  type = @type, salary=@salary where JobId = @jobId";
            SqlParameter[] sqlParams = new SqlParameter[6];
            sqlParams[0] = new SqlParameter("@name", name);
            sqlParams[1] = new SqlParameter("@skill", skill);
            sqlParams[2] = new SqlParameter("@description", description);
            sqlParams[3] = new SqlParameter("@type", type);
            sqlParams[4] = new SqlParameter("@salary", salary);
            sqlParams[5] = new SqlParameter("@jobId", id);
            db.Database.ExecuteSqlCommand(query, sqlParams);

            //Redirecting the control back to the List Jobs view. 
            return RedirectToAction("JobList");
        }

        //GET: Function to delete a job in the Job table. 
        public ActionResult DeleteJob(int id)
        {
            Debug.WriteLine("Deleting Jobs with the ID: ");
            Debug.WriteLine(id);

            //Query to delete the job with the specific jobId id
            string query = "delete from Jobs where JobId = @JobId";
            Debug.WriteLine(query);
            SqlParameter[] sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@JobId", id);
            db.Database.ExecuteSqlCommand(query, sqlParams);

            //Redirecting the control back to List Jobs view. 
            return RedirectToAction("JobList");
        }
    }
}
