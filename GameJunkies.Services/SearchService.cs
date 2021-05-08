using GameJunkies.Data;
using GameJunkies.Models.Console;
using GameJunkies.Models.Developer;
using GameJunkies.Models.Game;
using GameJunkies.Models.Genre;
using GameJunkies.Models.Publisher;
using GameJunkies.Models.Retailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Services
{
    public class SearchService
    {
        public IEnumerable<GameListItem> SimpleGameSearch(string searchText)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Games.Where(n => n.Title.Contains(searchText)).Select(e => new GameListItem { Id = e.Id, Title = e.Title, Created = e.CreatedUtc });

                return query.ToArray();
            }
        }
        public IEnumerable<ConsoleListItem> SimpleConsoleSearch(string searchText)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Consoles.Where(n => n.Name.Contains(searchText)).Select(e => new ConsoleListItem { ConsoleId = e.Id, Name = e.Name, Brand = e.Brand, CreatedUtc = e.CreatedUtc });

                return query.ToArray();
            }
        }
        public IEnumerable<RetailerListItem> SimpleRetailerSearch(string searchText)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Retailers.Where(n => n.Name.Contains(searchText)).Select(e => new RetailerListItem { RetailerId = e.Id, Name = e.Name, CreatedUtc = e.CreatedUtc });

                return query.ToArray();
            }
        }
        public IEnumerable<GenreListItem> SimpleGenreSearch(string searchText)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Genres.Where(n => n.Name.Contains(searchText)).Select(e => new GenreListItem
                {
                    Id = e.Id,
                    Name = e.Name,
                    CreatedUtc = e.CreatedUtc
                });

                return query.ToArray();
            }
        }
         public IEnumerable<PublisherListItem> SimplePublisherSearch(string searchText)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Publishers.Where(n => n.Name.Contains(searchText)).Select(e => new PublisherListItem { Name = e.Name, CreatedUtc = e.CreatedUtc, PublisherId = e.Id });

                return query.ToArray();
            }
        }
        public IEnumerable<DeveloperListItem> SimpleDeveloperSearch(string searchText)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Developers.Where(n => n.Name.Contains(searchText)).Select(e => new DeveloperListItem { Name = e.Name, CreatedUtc = e.CreatedUtc, DeveloperId = e.Id });

                return query.ToArray();
            }
        }
    }
}
