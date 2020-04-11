﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using HospitalProject.Data;
using HospitalProject.Models;

namespace HospitalProject.Controllers
{
    public class BlogsController : Controller
    {
        //create the db context to connect to the database
        private HospitalContext db = new HospitalContext();

        // GET: Blogs
        //get a list of all blogs in the index page
        public ActionResult Index()
        {
            //redirecting to the List method
            return RedirectToAction("List");
        }
        //If the user searches a keyword
        public ActionResult ListAdmin(string searchkey)
        {
            //check that it has a value (not null and not empty)
            if (!String.IsNullOrEmpty(searchkey))
            {
                //check the keyword in various columns (Title, Body, Date)
                List<Blog> blogs = db.Blogs.Where(blog =>
                        blog.Title.Contains(searchkey) ||
                        blog.Body.Contains(searchkey)
                        ).ToList();
                return View(blogs);
            }//if not show the list of all blogs
            else
            {
                List<Blog> blogs = db.Blogs.ToList();
                return View(blogs);
            }
        }        //If the user searches a keyword
        public ActionResult List(string searchkey)
        {
            //check that it has a value (not null and not empty)
            if (!String.IsNullOrEmpty(searchkey))
            {
                //check the keyword in various columns (Title, Body, Date -> first convert to string :https://stackoverflow.com/questions/901332/how-do-i-filter-linq-query-by-date)
                List<Blog> blogs = db.Blogs.Where(blog =>
                    blog.Title.Contains(searchkey) ||
                    blog.Body.Contains(searchkey)).ToList();
                return View(blogs);
            }//if not show the list of all blogs
            else
            {
                List<Blog> blogs = db.Blogs.ToList();
                return View(blogs);
            }
        }

        //Details of a blog post (News)
        public ActionResult Show(int id)
        {
            Blog selectedBlog = db.Blogs.Find(id);
            return View(selectedBlog);
        }




        
    }
}