using GameJunkies.Contracts;
using GameJunkies.Models.Console;
using GameJunkies.Models.ConsoleGame;
using GameJunkies.Models.Game;
using GameJunkies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameJunkies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IConsoleGameService _consoleGameService;

        public GameController(IGameService gameService, IConsoleGameService consoleGameService)
        {
            _gameService = gameService;
            _consoleGameService = consoleGameService;
        }
        // GET: Game
        public ActionResult Index()
        {
            if (TempData["list"]!=null)
            {
                return View(TempData["list"]);
            }
            //var service = new GameService();
            var model =_gameService.GetGames();
            return View(model);
        }
        
        public ActionResult Random()
        {
            //var service = new GameService();
            var request = _gameService.RandomGames();
            var model = request.Result;
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

            //var service = new GameService();

            if (_gameService.CreateGame(model)){
                TempData["SaveResult"] = "Your game was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Game could not be added.");
            return View(model);
            
        }
        public ActionResult Details(int id)
        {
           // var service = new GameService();
            var model = _gameService.GetGameById(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
           // var service = new GameService();
            var model = _gameService.GetGameEditById(id);
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
           // var service = new GameService();
            if (_gameService.UpdateGame(model))
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
            //var service = new GameService();
            var model = _gameService.GetGameById(id);
            
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            
            //var service = new GameService();
            _gameService.DeleteGame(id);
            TempData["SaveResult"] = "Your game was deleted";
            return RedirectToAction("Index");
        }
        public ActionResult ConsoleLink(int id)
        {
            //var service = new ConsoleGameService();
            var model = _consoleGameService.GetCreateLink(id);
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsoleLink(ConsoleGamesCreates model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var service = new ConsoleGameService();

            if (_consoleGameService.CreateConsoleGames(model))
            {
                TempData["SaveResult"] = "Your game was linked.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Game could not be linked.");
            return View(model);

        }
    }
}