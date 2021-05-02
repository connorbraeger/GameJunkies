using GameJunkies.Data;
using GameJunkies.Models.Publisher;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Services
{
    public class PublisherService
    {
        public bool CreatePublisher(PublisherCreate model)
        {
            var entity = new Publisher()
            {
                Name = model.Name,
                CompanySize = model.CompanySize,
                Country = model.Country,
                Rating = -1,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {

                ctx.Publishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PublisherListItem> GetPublishers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Publishers.Select(e => new PublisherListItem { Name = e.Name, CreatedUtc = e.CreatedUtc, PublisherId = e.Id });
                return query.ToArray();
            }

        }
        public PublisherDetail GetPublisherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Publishers.Single(e => e.Id == id);
                    return new PublisherDetail
                    {
                        PublisherId = entity.Id,
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
                    Debug.Print("Exception thrown while looking for Publisher");
                    Debug.Print(e.Message);
                    return null;
                }
            }
        }
        public bool UpdatePublisher(PublisherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Publishers.Single(e => e.Id == model.PublisherId);
                    entity.Name = model.Name;
                    entity.CompanySize = model.CompanySize;
                    entity.Country = model.Country;
                    entity.Rating = model.Rating;
                    entity.ModifiedUtc = DateTimeOffset.Now;
                    return ctx.SaveChanges() >= 1;
                }
                catch (Exception e)
                {

                    Debug.Print("Exception thrown while looking for publisher");
                    Debug.Print(e.Message);
                    return false;
                }


            }
        }
        public bool DeletePublisher(int publisherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Publishers.Single(e => e.Id == publisherId);
                    ctx.Publishers.Remove(entity);
                    return ctx.SaveChanges() >= 1;
                }
                catch (Exception e)
                {

                    Debug.Print("Exception thrown while looking for publisher");
                    Debug.Print(e.Message);
                    return false;
                }
            }
        }
    }
}
