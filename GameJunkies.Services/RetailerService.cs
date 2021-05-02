using GameJunkies.Data;
using GameJunkies.Models.Retailer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Services
{
    public class RetailerService
    {
        public bool CreateRetailer(RetailerCreate model)
        {
            var entity = new Retailer()
            {
                Name = model.Name,
                WebsiteUrl = model.WebsiteUrl,
                HasPhysicalLocations = model.HasPhysicalLocations,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Retailers.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }
        public IEnumerable<RetailerListItem> GetRetailers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Retailers.Select(e => new RetailerListItem { RetailerId = e.Id, Name = e.Name, CreatedUtc = e.CreatedUtc });
                return query.ToArray();
            }
        }
        public RetailerDetail GetRetailerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Retailers.Single(e => e.Id == id);
                    return new RetailerDetail
                    {
                        RetailerId = entity.Id,
                        Name = entity.Name,
                        WebsiteUrl = entity.WebsiteUrl,
                        CreatedUtc = entity.CreatedUtc,
                        HasPhysicalLocations = entity.HasPhysicalLocations,
                        ModifiedUtc = entity.ModifiedUtc
                    };
                }
                catch (Exception e)
                {

                    Debug.Print("Exception thrown while looking for retailer");
                    Debug.Print(e.Message);
                    return null;
                }
            }
        }
        public bool UpdateRetailer(RetailerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Retailers.Single(e => e.Id == model.Id);
                    entity.Name = model.Name;
                    entity.WebsiteUrl = model.WebsiteUrl;
                    entity.HasPhysicalLocations = model.HasPhysicalLocations;
                    entity.ModifiedUtc = DateTimeOffset.Now;
                    return ctx.SaveChanges() >= 1;
                }
                catch (Exception e)
                {

                    Debug.Print("Exception thrown while looking for retailer");
                    Debug.Print(e.Message);
                    return false;
                }
            }
        }
        public bool DeleteRetailer(int retailerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Retailers.Single(e => e.Id == retailerId);
                    ctx.Retailers.Remove(entity);
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
    }
}
