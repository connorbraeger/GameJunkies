using GameJunkies.Models.Retailer;
using GameJunkies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameJunkies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RetailerController : Controller
    {
        // GET: Retailer
        public ActionResult Index()
        {
            var service = new RetailerService();
            var model = service.GetRetailers();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RetailerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new RetailerService();

            if (service.CreateRetailer(model))
            {
                TempData["SaveResult"] = "Your retailer was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Retailer could not be added.");
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var service = new RetailerService();
            var model = service.GetRetailerById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = new RetailerService();
            var detail = service.GetRetailerById(id);
            var model = new RetailerEdit()
            {
                Id = detail.RetailerId,
                Name = detail.Name,
                WebsiteUrl = detail.WebsiteUrl,
                HasPhysicalLocations = detail.HasPhysicalLocations
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RetailerEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new RetailerService();
            if (service.UpdateRetailer(model))
            {
                TempData["SaveResult"] = "The retailer was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Retailer could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new RetailerService();
            var model = service.GetRetailerById(id);

            return View(model);
        }
    }
}