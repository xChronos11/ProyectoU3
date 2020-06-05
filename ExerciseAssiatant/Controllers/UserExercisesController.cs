using ExerciseAssiatant.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExerciseAssiatant.Controllers
{
    [Authorize]
    public class UserExercisesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: UserExercise
        public ActionResult Index(string id)
        {
            //var use = db.UserExercises.ToList();
            var realId = db.Userss.Where(u => u.usrId == id).FirstOrDefault().Id;
            var ls = db.UserExercises.Where(ue => ue.Usr.Id == realId).ToList();

            for (int i = 0; i < ls.Count; i++)
            {
                ls[i].ExerciseType = db.ExerciseTypes.Find(ls[i].ExerciseId);
            }

            return View(ls);
        }

        // GET: UserExercise/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserExercise/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseId = new SelectList(db.ExerciseTypes, "Id", "Name");
            return View();
        }

        // POST: UserExercise/Create
        [HttpPost]
        public ActionResult Create(UserExercise ue)
        {
            try
            {
                //ue.Cliente = db.Userss.Where(cl => cl.usrId == User.Identity.GetUserId()).ToList()[0];
                // TODO: Add insert logic here
                var uid = User.Identity.GetUserId();
                ue.Cliente = db.Clientes.Where(cl => cl.ApplicationUser.Id == uid).FirstOrDefault();
                ue.Usr = db.Userss.Where(u => u.usrId == uid).FirstOrDefault();
                db.UserExercises.Add(ue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserExercise/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserExercise/Edit/5
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

        // GET: UserExercise/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserExercise/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
