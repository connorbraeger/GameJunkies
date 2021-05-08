using GameJunkies.Models.Genre;
using GameJunkies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameJunkies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            if (TempData["list"] != null)
            {
                return View(TempData["list"]);
            }
            var service = new GenreService();
            var model = service.GetGenres();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new GenreService();

            if (service.CreateGenre(model))
            {
                TempData["SaveResult"] = "Your Genre was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Genre could not be added.");
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var service = new GenreService();
            var model = service.GetGenreById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = new GenreService();
            var detail = service.GetGenreById(id);
            var model = new GenreEdit()
            {
               Id = detail.Id,
                Name = detail.Name,
                Description = detail.Description
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GenreEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new GenreService();
            if (service.UpdateGenre(model))
            {
                TempData["SaveResult"] = "The genre was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Genre could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new GenreService();
            var model = service.GetGenreById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            var service = new GenreService();
            service.DeleteGenre(id);
            TempData["SaveResult"] = "Your genre was deleted";
            return RedirectToAction("Index");
        }
    }
}