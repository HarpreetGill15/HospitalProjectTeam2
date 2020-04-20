using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Web.Mvc;
using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.Models.ViewModels;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace HospitalProject.Controllers
{
    public class DiseasesController : Controller
    {
        // GET: Diseases
        private HospitalContext db = new HospitalContext();
        public ActionResult Index()
        {
            return View();
        }

        //function to show list of diseases in table
        public ActionResult List()
        {
            //query to get all diseases content
            string query = "Select * from Diseases";
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            List<Diseases> diseases = db.Diseases.SqlQuery(query, sqlparams.ToArray()).ToList();
            //returing diseases
            return View(diseases);
        }

        //function to show disease details using viewmodel
        public ActionResult Show(int id)
        {
            Debug.WriteLine("I am pulling disease with ID:"+id);
            Diseases disease = db.Diseases.SqlQuery("select * from Diseases where DiseaseID=@DiseaseID", new SqlParameter("@DiseaseID", id)).FirstOrDefault();
            ShowDisease viewmodel = new ShowDisease();
            viewmodel.Diseases = disease;
            //returning viewmodel
            return View(viewmodel);
        }

        //function to choose tips from drop down in add page
        public ActionResult Add()
        {
            List<Tips> tips = db.Tips.SqlQuery("select * from Tips").ToList();
            //returning tips to add page of diseases
            return View(tips);
        }

        //function to add diseases with diseasename,content and tipsID
        public ActionResult Add(string DiseaseName, string content, int TipsID)
        {
            Debug.WriteLine("I am adding DiseaseDetails with DiseaseName:"+DiseaseName + "Content:" + content + "TipsID" + TipsID);
            string query = "insert into Diseases (DiseaseName,content,TipsId) values (@DiseaseName,@content,@TipsID)";
            SqlParameter[] sqlparams = new SqlParameter[3]; //sql parameter with array size 3

            sqlparams[0] = new SqlParameter("@DiseaseName", DiseaseName);//ist item disease name
            sqlparams[1] = new SqlParameter("@content", content);//2nd item content
            sqlparams[2] = new SqlParameter("@TipsID", TipsID);//3rd item TipsID

            db.Database.ExecuteSqlCommand(query, sqlparams);
            //After adding disease redirecting to Lists page
            return RedirectToAction("List");

        }

        //function to provide previously added content of diseases
        public ActionResult Edit(int id)
        {
            Debug.WriteLine("I am pulling prevoiusly added content of disease with ID:" + id);
            //query to select a prticular disease to update
            Diseases selecteddisease = db.Diseases.SqlQuery("select * from Diseases where DiseaseID = @id", new SqlParameter("@id", id)).FirstOrDefault();
            //selecting tips
            List<Tips> tips = db.Tips.SqlQuery("select * from Tips").ToList();

            EditDisease editdiseaseViewModel = new EditDisease();
            editdiseaseViewModel.Diseases = selecteddisease;
            editdiseaseViewModel.Tips = tips;
            //returning view on edit disease page through viewwmodel
            return View(editdiseaseViewModel);
        }

        //function to update disease page content
        public ActionResult Edit(string DiseaseName, string content, int TipsID, int id)
        {
            Debug.WriteLine("I am updating disease content with diseasename" + DiseaseName + "Content" + content + "TipsID" + TipsID + "of diseaseID" + id);
            //query to update disease details
            string query = "update Diseases set DiseaseName = @DiseaseName,content = @content,TipsID = @TipsID where DiseaseID = @id";
            SqlParameter[] sqlparams = new SqlParameter[4]; //sql parameter with array size 4

            sqlparams[0] = new SqlParameter("@DiseaseName", DiseaseName);//ist item disease name
            sqlparams[1] = new SqlParameter("@content", content);//2nd item content
            sqlparams[2] = new SqlParameter("@TipsID", TipsID);//3rd item TipsID
            sqlparams[3] = new SqlParameter("@id", id);//fourth item id

            db.Database.ExecuteSqlCommand(query, sqlparams);
            //After editing disease details  redirecting to Lists page
            return RedirectToAction("List");

        }

        //deletion function to ask for confirmation whether to delete or not?
        public ActionResult DeleteConfirm(int id)
        {
            Debug.WriteLine("i am asking confirmation of deletion with id " + id);
            //query to selected all content of a aprticular disease
            string query = "select * from Diseases where DiseaseID = @id";
            SqlParameter param = new SqlParameter("@id", id);
            Diseases selecteddisease = db.Diseases.SqlQuery(query, param).FirstOrDefault();
            //returning selected disease
            return View(selecteddisease);
        }
        //function to delete disease content
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("I am deleting disease with Id :" + id);
            //query to select disease
            string query = "delete from Diseases where DiseaseID = @id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            //after deletion returning to Lists Page
            return RedirectToAction("List");
        }


    }
}