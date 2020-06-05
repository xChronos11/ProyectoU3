using ExerciseAssiatant.Models;
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
            return View(db.UserExercises.Where(ue => ue.Cliente.UserId == id));
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
                // TODO: Add insert logic here
                //ue.Cliente = db.Clientes
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
