using GameJunkies.Data;
using GameJunkies.Models;
using GameJunkies.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Services
{
    public class GameService
    {
        public bool CreateGame(GameCreate model)
        {
            var entity = new Game()
            {
                Title = model.Title,
                Description = model.Description,
                ParentalRating = model.ParentalRating,
                GenreId = model.GenreId,
                DeveloperId = model.DeveloperId,
                PublisherId = model.PublisherId,
                ReleaseDate = model.ReleaseDate,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
            {

            }
        }
        public IEnumerable<GameListItem> GetGames() 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Games.Select(e => new GameListItem { Id = e.Id, Title = e.Title, Created = e.CreatedUtc });

                return query.ToArray();
            }
            
        } 

    }
}
