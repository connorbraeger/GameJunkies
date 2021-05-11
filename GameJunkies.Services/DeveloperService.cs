using GameJunkies.Contracts;
using GameJunkies.Data;
using GameJunkies.Models.Developer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Services
{
    public class DeveloperService : IDeveloperService
    {
        public bool CreateDeveloper(DeveloperCreate model)
        {
            var entity = new Developer()
            {
                Name = model.Name,
                CompanySize = model.CompanySize,
                Country = model.Country,
                Rating = -1,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {

                ctx.Developers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DeveloperListItem> GetDevelopers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Developers.Select(e => new DeveloperListItem { Name = e.Name, CreatedUtc = e.CreatedUtc, DeveloperId = e.Id });
                return query.ToArray();
            }

        }
        public DeveloperDetail GetDeveloperById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Developers.Single(e => e.Id == id);
                    return new DeveloperDetail
                    {
                        DeveloperId = entity.Id,
                        Name = entity.Name,
                        CompanySize = entity.CompanySize,
                        Country = entity.Country,
                        Rating = entity.Rating,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
                }
                catch (Exception e)
                {
                    Debug.Print("Exception thrown while looking for developer");
                    Debug.Print(e.Message);
                    return null;
                }
            }
        }
        public bool UpdateDeveloper(DeveloperEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Developers.Single(e => e.Id == model.DeveloperId);
                    entity.Name = model.Name;
                    entity.CompanySize = model.CompanySize;
                    entity.Country = model.Country;
                    entity.Rating = model.Rating;
                    entity.ModifiedUtc = DateTimeOffset.Now;
                    return ctx.SaveChanges() >= 1;
                }
                catch (Exception e)
                {

                    Debug.Print("Exception thrown while looking for developer");
                    Debug.Print(e.Message);
                    return false;
                }


            }
        }
        public bool DeleteDeveloper(int developerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Developers.Single(e => e.Id == developerId);
                    ctx.Developers.Remove(entity);
                    return ctx.SaveChanges() >= 1;
                }
                catch (Exception e)
                {

                    Debug.Print("Exception thrown while looking for developer");
                    Debug.Print(e.Message);
                    return false;
                }
            }
        }
    }
}
