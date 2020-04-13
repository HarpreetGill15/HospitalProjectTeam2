using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject.Controllers
{
    public class FeedbacksController : Controller
    {
        private HospitalContext db = new HospitalContext();
        // GET: Feedbacks
        public ActionResult List()
        {
            List<Feedbacks> feedbacks = db.Feedbacks.SqlQuery("select * from Feedbacks").ToList();
            return View(feedbacks);
        }
        public ActionResult Add()
        {
            List<FeedbackTypes> feedbackTypes = db.FeedbackTypes.SqlQuery("Select * from FeedbackTypes").ToList();

            return View(feedbackTypes);
        }
        //add a feedback 
        //user view
        [HttpPost]
        public ActionResult Add(string fname, string lname, string email, string feedback, int type)
        {
            Debug.WriteLine("I am trying to add users feedback with first name: " + fname + " last name: " + lname + " email: " + email +
                " feedback of " + feedback + " type of id " + type);

            string query = "insert into Feedbacks (FirstName, LastName, Email, Feedback, typeId) values (@fname, @lname, @email, @feedback, @type)";

            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@fname", fname);
            sqlParameters[1] = new SqlParameter("@lname", lname);
            sqlParameters[2] = new SqlParameter("@email", email);
            sqlParameters[3] = new SqlParameter("@feedback", feedback);
            sqlParameters[4] = new SqlParameter("@type", type);

            db.Database.ExecuteSqlCommand(query, sqlParameters);

            return RedirectToAction("List");
        }

        //update a feedback 
        //admin view
        public ActionResult Update(int id)
        {
            Feedbacks feedbacks = db.Feedbacks.SqlQuery("select * from feedbacks where id = @id", new SqlParameter("@id", id)).FirstOrDefault();

            List<FeedbackTypes> feedbackTypes = db.FeedbackTypes.SqlQuery("Select * from FeedbackTypes").ToList();

            UpdateFeedback update = new UpdateFeedback();
            update.Feedbacks = feedbacks;
            update.feedbackTypes = feedbackTypes;
            return View(update);
        }
        [HttpPost]
        public ActionResult Update(int id, string fname, string lname, string email, string feedback, int type)
        {
            Debug.WriteLine("I am trying to update feedback with the id of " + id + " with the first name: " + fname + " last name: " + lname + " email: " + email +
                " feedback of " + feedback + " type of id " + type);

            string query = "update Feedbacks set FirstName = @fname, LastName = @lname, Email = @email, Feedback = @feedback, typeId = @type where id = @id";

            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@fname", fname);
            sqlParameters[1] = new SqlParameter("@lname", lname);
            sqlParameters[2] = new SqlParameter("@email", email);
            sqlParameters[3] = new SqlParameter("@feedback", feedback);
            sqlParameters[4] = new SqlParameter("@type", type);
            sqlParameters[5] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, sqlParameters);

            return RedirectToAction("List");
        }

        //delete feedback
        //admin view
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //attach feedback to department
        //admin view
        public ActionResult AddDepartment(int feedbacktype, int departmentid)
        {
            Debug.WriteLine("Attach department with the id of :" + departmentid + " to the feedback with the id of :" + feedbacktype);

            //check if they are already attached
            string check = "select * from FeedbackTypeDepartments where Departments_id = @did and FeedbackType_typeId = @fid";
            SqlParameter[] sql = new SqlParameter[2];
            sql[0] = new SqlParameter("@did", departmentid);
            sql[1] = new SqlParameter("@fid", feedbacktype);

            List<Feedbacks> feedbacks = db.Feedbacks.SqlQuery(check, sql).ToList();
            if (feedbacks.Count <= 0)
            {
                string query = "insert into FeedbackTypeDepartments (Departments_id,FeedbackType_typeId) values (@did, @fid)";
                SqlParameter[] sqlParameter = new SqlParameter[2];
                sqlParameter[0] = new SqlParameter("@did", departmentid);
                sqlParameter[1] = new SqlParameter("@fid", feedbacktype);

                db.Database.ExecuteSqlCommand(query, sqlParameter);
            }
            return RedirectToAction("List");
        }
        //detach feedback to department 
        //admin view
        public ActionResult DetachDeparment(int feedbacktype, int departmentid)
        {
            Debug.WriteLine("Deattach department with the id of :" + departmentid + " to the feedback with the id of :" + feedbacktype);

            string query = "delete from FeedbackTypeDepartments where Departments_id = @did and FeedbackType_typeId = @fid";
            SqlParameter[] sqlParameter = new SqlParameter[2];
            sqlParameter[0] = new SqlParameter("@did", departmentid);
            sqlParameter[1] = new SqlParameter("@fid", feedbacktype);

            db.Database.ExecuteSqlCommand(query, sqlParameter);

            return RedirectToAction("List");
        }
    }
}