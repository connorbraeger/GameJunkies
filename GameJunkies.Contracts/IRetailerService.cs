using GameJunkies.Models.Retailer;
using System.Collections.Generic;

namespace GameJunkies.Contracts
{
    public interface IRetailerService
    {
        bool CreateRetailer(RetailerCreate model);
        bool DeleteRetailer(int retailerId);
        RetailerDetail GetRetailerById(int id);
        IEnumerable<RetailerListItem> GetRetailers();
        bool UpdateRetailer(RetailerEdit model);
    }
}