﻿using ExerciseAssiatant.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExerciseAssiatant.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            //User.Identity.IsAuthenticated && 
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Posts");
            }

            ViewBag.posts = db.Posts.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}