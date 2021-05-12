using GameJunkies.Models.Console;
using GameJunkies.Models.Developer;
using GameJunkies.Models.Game;
using GameJunkies.Models.Genre;
using GameJunkies.Models.Publisher;
using GameJunkies.Models.Retailer;
using System.Collections.Generic;

namespace GameJunkies.Contracts
{
    public interface ISearchService
    {
        IEnumerable<ConsoleListItem> SimpleConsoleSearch(string searchText);
        IEnumerable<DeveloperListItem> SimpleDeveloperSearch(string searchText);
        IEnumerable<GameListItem> SimpleGameSearch(string searchText);
        IEnumerable<GenreListItem> SimpleGenreSearch(string searchText);
        IEnumerable<PublisherListItem> SimplePublisherSearch(string searchText);
        IEnumerable<RetailerListItem> SimpleRetailerSearch(string searchText);
    }
}