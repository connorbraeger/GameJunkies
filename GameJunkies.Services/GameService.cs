using GameJunkies.Data;
using GameJunkies.Models;
using GameJunkies.Models.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                CreatedUtc = DateTimeOffset.Now,
                Rating = -1
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
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
        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                try { var entity = ctx.Games.Single(e => e.Id == id);
                    return new GameDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description,
                        ParentalRating = entity.ParentalRating,
                        Genre = entity.Genre.Name,
                        Developer = entity.Developer.Name,
                        Publisher = entity.Publisher.Name,
                        Rating = entity.Rating,
                        ReleaseDate = entity.ReleaseDate,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
                }
                catch(Exception e)
                {
                    Debug.Print("Exception thrown while looking for game");
                    Debug.Print(e.Message);
                    return null;
                }
                
            }
        }
        public GameEdit GetGameEditById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var edit= ctx.Games.Where(e => e.Id == id).Select(model => new GameEdit {GameId = id, Title = model.Title,
                Description = model.Description, ParentalRating = model.ParentalRating, GenreId = model.GenreId, DeveloperId = model.DeveloperId, PublisherId = model.PublisherId, Rating = model.Rating, ReleaseDate = model.ReleaseDate
                }
                ).ToList();
                return edit[0];
            }
        }
        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Games.Single(e => e.Id == model.GameId);
                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    entity.ParentalRating = model.ParentalRating;
                    entity.GenreId = model.GenreId;
                    entity.DeveloperId = model.DeveloperId;
                    entity.PublisherId = model.PublisherId;
                    entity.Rating = model.Rating;
                    entity.ReleaseDate = model.ReleaseDate;
                    return ctx.SaveChanges() >= 1;

                }
                catch (Exception e)
                {
                    Debug.Print("Exception thrown while looking for game");
                    Debug.Print(e.Message);
                    return false;
                }
            }
        }
        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.Single(e => e.Id == gameId);
                ctx.Games.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }
        }

    }
}
