using GameJunkies.Models.Publisher;
using GameJunkies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameJunkies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Index()
        {
            var service = new PublisherService();
            var model = service.GetPublishers();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new PublisherService();

            if (service.CreatePublisher(model))
            {
                TempData["SaveResult"] = "Your publisher was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Publisher could not be added.");
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var service = new PublisherService();
            var model = service.GetPublisherById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = new PublisherService();
            var detail = service.GetPublisherById(id);
            var model = new PublisherEdit()
            {
                PublisherId = detail.PublisherId,
                Name = detail.Name,
                CompanySize = detail.CompanySize,
                Country = detail.Country,
                Rating = detail.Rating
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PublisherEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.PublisherId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new PublisherService();
            if (service.UpdatePublisher(model))
            {
                TempData["SaveResult"] = "The publisher was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Publisher could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new PublisherService();
            var model = service.GetPublisherById(id);

            return View(model);
        }
    }
}