using GameJunkies.Models.Publisher;
using System.Collections.Generic;

namespace GameJunkies.Contracts
{
    public interface IPublisherService
    {
        bool CreatePublisher(PublisherCreate model);
        bool DeletePublisher(int publisherId);
        PublisherDetail GetPublisherById(int id);
        IEnumerable<PublisherListItem> GetPublishers();
        bool UpdatePublisher(PublisherEdit model);
    }
}