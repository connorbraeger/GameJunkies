using GameJunkies.Data;
using GameJunkies.Models.Genre;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Services
{
    public class GenreService
    {
        public bool CreateGenre(GenreCreate model)
        {
            var entity = new Genre()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GenreListItem> GetGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Genres.Select(e => new GenreListItem
                {
                    Id = e.Id,
                    Name = e.Name,
                    CreatedUtc = e.CreatedUtc
                });
                return query.ToArray();
            }
        }
        public GenreDetail GetGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Genres.Single(e => e.Id == id);
                    return new GenreDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Description = entity.Description,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
                }
                catch (Exception e)
                {
                    Debug.Print("Exception thrown while looking for genre");
                    Debug.Print(e.Message);
                    return null;
                    
                }
            }
        }
        public bool UpdateGenre(GenreEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Genres.Single(e => e.Id == model.Id);
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.ModifiedUtc = DateTimeOffset.Now;
                    return ctx.SaveChanges() == 1;
                }
                catch (Exception e)
                {

                    Debug.Print("Exception thrown while looking for genre");
                    Debug.Print(e.Message);
                    return false;
                }
            }
        }
        public bool DeleteGenre(int genreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Genres.Single(e => e.Id == genreId);
                    ctx.Genres.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
                catch (Exception e)
                {

                    Debug.Print("Exception thrown while looking for genre");
                    Debug.Print(e.Message);
                    return false;
                }
            }
        }
    }
}
