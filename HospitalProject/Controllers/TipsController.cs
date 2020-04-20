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
    public class TipsController : Controller
    {
        // GET: Tips
        private HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            return View();
        }

        //function to print details of tips
        public ActionResult List()
        {
            //query to select all details from tips table
            string query = "Select * from Tips";
            List<Tips> selectedTips = db.Tips.SqlQuery(query).ToList();
            //After executing query returning and printing all tips to Lists Page
            return View(selectedTips);
        }

        public ActionResult Add()
        {
            return View();
        }

        //function to add Tips information
        [HttpPost]
        public ActionResult Add(string tipname,string tipdate)
        {
            Debug.WriteLine("I am extracting data of Tips with tipname:" + tipname + "and tipdate" + tipdate);
            string query = "insert into Tips (TipName,Date) values (@tipname,@tipdate)";
            SqlParameter[] sqlparams = new SqlParameter[2];//SQL parameter with size of array 2
            sqlparams[0] = new SqlParameter("@tipname", tipname);//first item tipname
            sqlparams[1] = new SqlParameter("@tipdate", tipdate);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            //After inserting tips details to database redirecting to Lists Page
            return RedirectToAction("List");
        }

        //function to show tipdetails on clicking tipname
        public ActionResult Show(int id)
        {
            Debug.WriteLine(" I am getting details of Tip with id:" + id);
            //query to select all details of tip whose TipID matches with id
            string query = "select * from Tips where TipID = @id";
            var parameter = new SqlParameter("@id", id);
            Tips selectedtip = db.Tips.SqlQuery(query, parameter).FirstOrDefault();
            //Returning data of selected tip
            return View(selectedtip);
        }

        //function to show previously added tip detail on Edit page
        public ActionResult Edit(int id)
        {
            Debug.WriteLine("I am pulling prevoiusly added content of Tip with ID:" + id);
            //query to select particular tips detail
            string query = "select * from Tips where TipID = @id";
            var parameter = new SqlParameter("@id", id);
            Tips selectedtip = db.Tips.SqlQuery(query, parameter).FirstOrDefault();
            //returning tipsdata to show in respective fields
            return View(selectedtip);
        }

        //function to edit tip details
        [HttpPost]
        public ActionResult Edit(int id, string tipname,string tipdate)
        {
            Debug.WriteLine("I am updating Tips content with tipname" + tipname + "tipdate" + tipdate + "of tip with ID" + id);
            //query to update tip details
            string query = "update Tips set TipName = @tipname,Date = @tipdate where TipID = @id";
            SqlParameter[] sqlparams = new SqlParameter[3];
            sqlparams[0] = new SqlParameter("@tipname", tipname);
            sqlparams[1] = new SqlParameter("@Date", tipdate);
            sqlparams[2] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            //After updating redirecting to Lists page
            return RedirectToAction("List");
        }

        //function to first ask a confirmation message to admin with Tipname
        public ActionResult DeleteConfirm(int id)
        {
            Debug.WriteLine("i am asking confirmation of tip id : " + id +"to delete");
            string query = "select * from Tips where TipsID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Tips selectedtip = db.Tips.SqlQuery(query, param).FirstOrDefault();
            return View(selectedtip);
        }
        //function to delete a specific tip
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("I am deleting tip with id:" + id);
            //query to delete all details of tips with respective tipID
            string query = "delete from Tips where TipsID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            //unsetting the tips for all diseases because tips are associated with diseases
            string refquery = "update disease set TipID = '' where TipID=@id";
            db.Database.ExecuteSqlCommand(refquery, param);
            //returning to Lists page after deletion of tipdetails
            return RedirectToAction("List");
        }
    }
}