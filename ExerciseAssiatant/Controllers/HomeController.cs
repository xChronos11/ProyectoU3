using ExerciseAssiatant.Models;
using Microsoft.AspNet.Identity;
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
        public void updaCalc(List<UserExercise> ls = null)
        {
            var id = User.Identity.GetUserId();
            var usr = db.Userss.Where(u => u.usrId == id).FirstOrDefault();
            ViewBag.usr = usr;
            ViewBag.iw = Utilities.Antropometric.idealWeight(ViewBag.usr.Height);

            if (ls == null)
            {
                var realId = db.Userss.Where(u => u.usrId == id).FirstOrDefault().Id;
                ls = db.UserExercises.Where(ue => ue.Usr.Id == realId).ToList();
            }

            float calories = 0;
            foreach (UserExercise ex in ls)
            {
                var curr = db.ExerciseTypes.Find(ex.ExerciseId);
                calories += usr.Weight * curr.Cal4Hour * (float)ex.Duration.TotalHours;
            }

            ViewBag.iw_diff = Math.Truncate(ViewBag.usr.Weight - ViewBag.iw - (calories / ExerciseAssiatant.Utilities.Antropometric.calories4Kilogram));
            ViewBag.cals = ExerciseAssiatant.Utilities.Antropometric.calories4Kilogram * ViewBag.iw_diff;
        }

        public ActionResult Index()
        {
            //User.Identity.IsAuthenticated && 
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Posts");
            } else
            {
                if (User.Identity.IsAuthenticated)
                {
                    updaCalc();
                }
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