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
    public class DepartmentsController : Controller
    {
        private HospitalContext db = new HospitalContext();
        // GET: Departments
        public ActionResult List()
        {
            List<Departments> departments = db.Departments.SqlQuery("Select * from Departments").ToList();
            return View(departments);
        }
        //show department 
        //show related feedback types
        public ActionResult Show(int id)
        {
            Departments departments = db.Departments.SqlQuery("Select * from Departments where id = @id", new SqlParameter("@id", id)).FirstOrDefault();

            List<FeedbackTypes> types = db.FeedbackTypes.SqlQuery("Select * from FeedbackTypes join FeedbackTypesDepartments on typeId = FeedbackTypes_typeId where Departments_id = @id", new SqlParameter("@id", id)).ToList();

            ShowDepartment show = new ShowDepartment();

            show.Department = departments;
            show.types = types;
            return View(show);
        }
        //add department view
        //admin only view
        public ActionResult Add()
        {

            return View();
        }
        //add department post
        [HttpPost]
        public ActionResult Add(string department, string email)
        {
            Debug.WriteLine("Adding department with the name : "+department+" and the email of "+email);

            string query = "insert into Departments (name, email) values (@name, @email)";

            SqlParameter[] sqlParameters = new SqlParameter[2];

            sqlParameters[0] = new SqlParameter("@name", department);
            sqlParameters[1] = new SqlParameter("@email", email);

            db.Database.ExecuteSqlCommand(query, sqlParameters);

            return RedirectToAction("List");

        }
        //update department
        //show related feedback types 
        public ActionResult Update(int id)
        {
            Departments departments = db.Departments.SqlQuery("Select * from Departments where id = @id", new SqlParameter("@id", id)).FirstOrDefault();
            return View(departments);
        }
    }
}