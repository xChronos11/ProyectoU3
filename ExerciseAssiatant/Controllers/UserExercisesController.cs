using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExerciseAssiatant.Models;
using Microsoft.AspNet.Identity;

namespace ExerciseAssiatant.Controllers
{
    public class UserExercisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AllExcercise() 
        {
            var userExercise = db.UserExercises.ToList();
            return View();
        }
        // GET: UserExercises
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var a = db.Clientes.Where(ad => ad.UserId == user).FirstOrDefault();
            var userExcercises = db.UserExercises.Include(u => u.Cliente).Where(us => us.Cliente.Id == a.Id).ToList();

            return View(userExcercises);
        }


        // GET: UserExercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserExercise userExercise = db.UserExercises.Find(id);
            if (userExercise == null)
            {
                return HttpNotFound();
            }
            return View(userExercise);
        }

        // GET: UserExercises/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseId = new SelectList(db.Exercises, "Id", "Name");
            return View();
        }

        // POST: UserExercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( UserExercise userExercise)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                var adm = db.Clientes.Where(a => a.UserId == userid).FirstOrDefault();
                userExercise.ExerciseId = adm.Id;
                db.UserExercises.Add(userExercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(userExercise);
        }

        // GET: UserExercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserExercise userExercise = db.UserExercises.Find(id);
            if (userExercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseId = new SelectList(db.Exercises, "Id", "Name", userExercise.ExerciseId);
            return View(userExercise);
        }

        // POST: UserExercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExerciseId,Duration,Date")] UserExercise userExercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userExercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseId = new SelectList(db.Exercises, "Id", "Name", userExercise.ExerciseId);
            return View(userExercise);
        }

        // GET: UserExercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserExercise userExercise = db.UserExercises.Find(id);
            if (userExercise == null)
            {
                return HttpNotFound();
            }
            return View(userExercise);
        }

        // POST: UserExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserExercise userExercise = db.UserExercises.Find(id);
            db.UserExercises.Remove(userExercise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
