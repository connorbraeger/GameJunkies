using GameJunkies.Models.ConsoleGame;
using GameJunkies.Models.Game;
using GameJunkies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameJunkies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {

            var service = new GameService();
            var model = service.GetGames();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new GameService();

            if (service.CreateGame(model)){
                TempData["SaveResult"] = "Your game was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Game could not be added.");
            return View(model);
            
        }
        public ActionResult Details(int id)
        {
            var service = new GameService();
            var model = service.GetGameById(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = new GameService();
            var model = service.GetGameEditById(id);
            return View(model);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.GameId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new GameService();
            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "The game was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Game could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new GameService();
            var model = service.GetGameById(id);
            
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            
            var service = new GameService();
            service.DeleteGame(id);
            TempData["SaveResult"] = "Your game was deleted";
            return RedirectToAction("Index");
        }
        public ActionResult ConsoleLink(int id)
        {
            ViewData["GameId"] = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsoleLink(ConsoleGameCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new ConsoleGameService();

            if (service.CreateConsoleGame(model))
            {
                TempData["SaveResult"] = "Your game was linked.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Game could not be alinked.");
            return View(model);

        }
    }
}