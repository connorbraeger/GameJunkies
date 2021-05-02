using GameJunkies.Data;
using GameJunkies.Models.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = GameJunkies.Data.Console;

namespace GameJunkies.Services
{
    public class ConsoleService
    {
        public bool CreateConsole(ConsoleCreate model)
        {
            var entity = new Console()
            {
                Name = model.Name,
                Description = model.Description,
                Brand = model.Brand,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                Rating = -1
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Consoles.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<ConsoleListItem> GetConsoles()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Consoles.Select(e => new ConsoleListItem { ConsoleId = e.Id, Name = e.Name, Brand = e.Brand, CreatedUtc = e.CreatedUtc });
                return query.ToArray();
            }
        }
        public ConsoleDetail GetConsoleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Consoles.Single(e => e.Id == id);
                    return new ConsoleDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Description = entity.Description,
                        Brand = entity.Brand,
                        Price = entity.Price,
                        Rating = entity.Rating,
                        ReleaseDate = entity.ReleaseDate,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
                }
                catch (Exception e)
                {

                    Debug.Print("Exception thrown while looking for console");
                    Debug.Print(e.Message);
                    return null;
                }
            }
        }
        public bool UpdateConsole(ConsoleEdit model) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Consoles.Single(e => e.Id == model.ConsoleId);
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.Brand = model.Brand;
                    entity.Price = model.Price;
                    entity.ReleaseDate = model.ReleaseDate;
                    entity.ModifiedUtc = DateTimeOffset.Now;
                    return ctx.SaveChanges() >= 1;
                }
                catch (Exception e)
                {
                    Debug.Print("Exception thrown while looking for console");
                    Debug.Print(e.Message);
                    return false;

                }
            }
        }
        public bool DeleteConsole(int consoleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Consoles.Single(e => e.Id == consoleId);
                ctx.Consoles.Remove(entity);
                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
