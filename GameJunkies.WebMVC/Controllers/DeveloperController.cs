using GameJunkies.Contracts;
using GameJunkies.Models.Developer;
using GameJunkies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameJunkies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _developerService;
        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }
        // GET: Developer
        public ActionResult Index()
        {
            if (TempData["list"] != null)
            {
                return View(TempData["list"]);
            }
           // var service = new DeveloperService();
            var model = _developerService.GetDevelopers();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeveloperCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

          //  var service = new DeveloperService();

            if (_developerService.CreateDeveloper(model))
            {
                TempData["SaveResult"] = "Your developer was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Developer could not be added.");
            return View(model);

        }
        public ActionResult Details(int id)
        {
           // var service = new DeveloperService();
            var model = _developerService.GetDeveloperById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
           // var service = new DeveloperService();
            var detail = _developerService.GetDeveloperById(id);
            var model = new DeveloperEdit()
            {
                DeveloperId = detail.DeveloperId,
                Name = detail.Name,
                CompanySize = detail.CompanySize,
                Country = detail.Country,
                Rating = detail.Rating
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DeveloperEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.DeveloperId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
           // var service = new DeveloperService();
            if (_developerService.UpdateDeveloper(model))
            {
                TempData["SaveResult"] = "The developer was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Developer could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
           // var service = new DeveloperService();
            var model = _developerService.GetDeveloperById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            //var service = new DeveloperService();
            _developerService.DeleteDeveloper(id);
            TempData["SaveResult"] = "Your developer was deleted";
            return RedirectToAction("Index");
        }
    }
}