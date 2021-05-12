using GameJunkies.Contracts;
using GameJunkies.Models.Console;
using GameJunkies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameJunkies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConsoleController : Controller
    {
        private readonly IConsoleService _consoleService;

        public ConsoleController(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }
        // GET: Console
        public ActionResult Index()
        {
            if (TempData["list"] != null)
            {
                return View(TempData["list"]);
            }
            //var service = new ConsoleService();
            var model = _consoleService.GetConsoles();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsoleCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var service = new ConsoleService();

            if (_consoleService.CreateConsole(model))
            {
                TempData["SaveResult"] = "Your console was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Console could not be added.");
            return View(model);

        }
        public ActionResult Details(int id)
        {
          //  var service = new ConsoleService();
            var model = _consoleService.GetConsoleById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
           // var service = new ConsoleService();
            var detail = _consoleService.GetConsoleById(id);
            var model = new ConsoleEdit() 
            {
                ConsoleId = detail.Id,
                Name = detail.Name,
                Description = detail.Description,
                Brand = detail.Brand,
                Price = detail.Price,
                ReleaseDate = detail.ReleaseDate
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConsoleEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ConsoleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
           // var service = new ConsoleService();
            if (_consoleService.UpdateConsole(model))
            {
                TempData["SaveResult"] = "The console was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Console could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
         //   var service = new ConsoleService();
            var model = _consoleService.GetConsoleById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

           // var service = new ConsoleService();
            _consoleService.DeleteConsole(id);
            TempData["SaveResult"] = "Your console was deleted";
            return RedirectToAction("Index");
        }
    }
}