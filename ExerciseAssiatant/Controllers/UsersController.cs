using ExerciseAssiatant.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExerciseAssiatant.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
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
        public ActionResult ViewProfile()
        {
            updaCalc();
            var id = User.Identity.GetUserId();
            var user = db.Users.Find(id);
            return View(user);
        }
        
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EditProfile(HttpPostedFileBase Picture)
        {
            if (Picture != null)
            {
                string nombreArchivo = System.IO.Path.GetFileName(Picture.FileName);
                string filepath = "~/Content/img/perfil/" + User.Identity.GetUserName() + "_" + nombreArchivo;
                Picture.SaveAs(Server.MapPath(filepath));

                var id = User.Identity.GetUserId();
                var userdb = db.Users.Find(id);
                userdb.Picture = User.Identity.GetUserName() + "_" + nombreArchivo;
                db.Entry(userdb).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ViewProfile", "Users");

        }
    }
}
