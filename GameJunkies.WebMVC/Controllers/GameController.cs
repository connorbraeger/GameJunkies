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
    }
}