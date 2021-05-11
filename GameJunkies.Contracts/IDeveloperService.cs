using GameJunkies.Models.Developer;
using System.Collections.Generic;

namespace GameJunkies.Contracts
{
    public interface IDeveloperService
    {
        bool CreateDeveloper(DeveloperCreate model);
        bool DeleteDeveloper(int developerId);
        DeveloperDetail GetDeveloperById(int id);
        IEnumerable<DeveloperListItem> GetDevelopers();
        bool UpdateDeveloper(DeveloperEdit model);
    }
}