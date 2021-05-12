using GameJunkies.Contracts;
using GameJunkies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameJunkies.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        // GET: Search
        public ActionResult Index(string type, string searchText)
        {
            var service = new SearchService();
            switch (type.ToLower())
            {

                case ("game"):
                    TempData["list"] = service.SimpleGameSearch(searchText);
                    return RedirectToAction("index", "game");
                case ("console"):
                    TempData["list"] = service.SimpleConsoleSearch(searchText);
                    return RedirectToAction("index", "console");
                case ("retailer"):
                    TempData["list"] = service.SimpleRetailerSearch(searchText);
                    return RedirectToAction("index", "retailer");
                case ("genre"):
                    TempData["list"] = service.SimpleGenreSearch(searchText);
                    return RedirectToAction("index", "genre");
                case ("publisher"):
                    TempData["list"] = service.SimplePublisherSearch(searchText);
                    return RedirectToAction("index", "game");
                case ("developer"):
                    TempData["list"] = service.SimpleDeveloperSearch(searchText);
                    return RedirectToAction("index", "game");
                default:
                    TempData["SearchResult"] = "No item of type " + type + " containing : " + searchText + " found.";
                    break;

            }
            return RedirectToAction("index", "home");


        }

    }  
}