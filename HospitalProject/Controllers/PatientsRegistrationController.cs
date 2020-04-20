using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalProject.Models;
using HospitalProject.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Diagnostics;
namespace HospitalProject.Controllers
{
    public class PatientsRegistrationController : Controller
    {
        // GET: Patients
        private HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            // At first we have to write query to get all the patients in the system from database table
            string query = "Select * from PatientsRegistration";
            List<PatientsRegistration> patients = db.PatientsRegistration.SqlQuery(query).ToList();
            //returing list of patients
            return View(patients);
        }

        [HttpPost]
        public ActionResult Add(string firstname, string lastname, string address, string patientemail, string city, string postalcode, string gender, int phonenumber, string dob, string emergencycontact, int emergencynumber)
        {
            // writing debig.writeline to check on console what values are fetched for respective fields
            Debug.WriteLine("I am writing patient records to database with firstname:" + firstname + ",lastname:" + lastname + ",Email:" +
                patientemail + ",Address:" + address + ",City:" + city + ",PostalCode:" + postalcode + "Gender:" + gender + ",PhoneNumber:" + phonenumber + ",DOB" + dob + ",Emergency Contact" + emergencycontact + "Emergency Number:" + emergencynumber);
            //writing query to insert patients records into patient registration table
            string query = "insert into PatientsRegistration (firstname,lastname,address,email,city,postalcode,gender,phone,dob,emergencycontactname,emergencycontactnumber values (@firstname,@lastname,@address,@patientemail,@city,@postalcode,@gender,@phonenumber,@dob,@emergencycontact,@emergencynumber)";
            SqlParameter[] sqlparams = new SqlParameter[11];
            sqlparams[0] = new SqlParameter("@firstname", firstname);//first item firstname
            sqlparams[1] = new SqlParameter("@lastname", lastname);//second item lastname
            sqlparams[2] = new SqlParameter("@address", address);//third item address
            sqlparams[3] = new SqlParameter("@patientemail", patientemail);//fourth item email
            sqlparams[4] = new SqlParameter("@city", city);//fifth item city
            sqlparams[5] = new SqlParameter("@postalcode", postalcode);//sixth item postalcode
            sqlparams[6] = new SqlParameter("@gender", gender);//seventh item gender
            sqlparams[7] = new SqlParameter("@phonenumber", phonenumber);//eighth item phonenumber
            sqlparams[8] = new SqlParameter("@dob", dob);//nineth item date of birth
            sqlparams[9] = new SqlParameter("@emergencycontact", emergencycontact);//tenth item emergency contact name
            sqlparams[10] = new SqlParameter("@emergencynumber", emergencynumber);//eleventh item emergency contact number

            db.Database.ExecuteSqlCommand(query, sqlparams);
            //After inserting values to database redirecting to lists page
            return RedirectToAction("List");
        }

        //Displaying the previously added record of patient in respective fields
        public ActionResult Edit(int id)
        {

            Debug.WriteLine("I am pulling prevoiusly added content of Patients with ID:" + id);
            //query to get all the details of patients from table with respective id of patient
            string query = "select * from PatientsRegistration where id = @id";
            var parameter = new SqlParameter("@id", id);
            PatientsRegistration selectedpatient = db.PatientsRegistration.SqlQuery(query, parameter).FirstOrDefault();
            //returning view of a selected patient to display data in respective fields on edit page of patient
            return View(selectedpatient);
        }

        //updating records of patient
        [HttpPost]
        public ActionResult Edit(int id, string firstname, string lastname, string address, string patientemail, string city, string postalcode, string gender, int phonenumber, string dob, string emergencycontact, int emergencynumber)
        {
            // writing data in console to check what data i have fetched
            Debug.WriteLine("I am trying to edit patient records with id:" + id + " firstname:" + firstname + ",lastname:" + lastname + ",Email:" +
                 patientemail + ",Address:" + address + ",City:" + city + ",PostalCode:" + postalcode + "Gender:" + gender + ",PhoneNumber:" + phonenumber + ",DOB" + dob + ",Emergency Contact" + emergencycontact + "Emergency Number:" + emergencynumber);
            // writing update query to edit records of patient
            string query = "update PatientsRegistration set firstname = @firstname,lastname = @lastname,address = @address,email = @patientemail,city = @city,postalcode = @postalcode ,gender = @gender,phone = @phonenumber,dob = @dob , emergencycontactname = @emergencycontact , emergencycontactnumber = @emergencynumber where id =@id";
            SqlParameter[] sqlparams = new SqlParameter[12];//SQL parameter with size of array 11
            sqlparams[0] = new SqlParameter("@firstname", firstname);//first item firstname
            sqlparams[1] = new SqlParameter("@lastname", lastname);//second item lastname
            sqlparams[2] = new SqlParameter("@address", address);//third item address
            sqlparams[3] = new SqlParameter("@patientemail", patientemail);//fourth item email
            sqlparams[4] = new SqlParameter("@city", city);//fifth item city
            sqlparams[5] = new SqlParameter("@postalcode", postalcode);//sixth item postalcode
            sqlparams[6] = new SqlParameter("@gender", gender);//seventh item gender
            sqlparams[7] = new SqlParameter("@phonenumber", phonenumber);//eighth item phonenumber
            sqlparams[8] = new SqlParameter("@dob", dob);//nineth item date of birth
            sqlparams[9] = new SqlParameter("@emergencycontact", emergencycontact);//tenth item emergency contact name
            sqlparams[10] = new SqlParameter("@emergencynumber", emergencynumber);//eleventh item emergency contact number
            sqlparams[11] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            //After editing values to database redirecting to lists page
            return RedirectToAction("List");
        }
        
    
        // Showing details of patient
        public ActionResult Show(int id)
        {
            Debug.WriteLine(" I am getting details of Patients with id:" + id);
            //writing query to select a particular patient
            string query = "select * from PatientsRegistration where id =@id";
            var parameter = new SqlParameter("@id", id);
            PatientsRegistration selectedpatient = db.PatientsRegistration.SqlQuery(query, parameter).FirstOrDefault();
            //returning records of a specific patient
            return View(selectedpatient);
        }

        //function to ask first for confirmation whether to delete a particular patient or not
        public ActionResult DeleteConfirm(int id)
        {
            Debug.WriteLine("i am asking confirmation of patients id : " + id + "to delete");
            //query to select a particular patient to delete
            string query = "select * from PatientsRegistration where id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            PatientsRegistration selectedpatient = db.PatientsRegistration.SqlQuery(query, param).FirstOrDefault();
            return View(selectedpatient);
        }
        //function to delete a particular patient
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("I am deleting patients with id:" + id);
            string query = "delete from PatientsRegistration where id=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            //after deleting redirecting to list page
            return RedirectToAction("List");
        }


    }
}