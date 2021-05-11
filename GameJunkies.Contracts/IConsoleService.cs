using GameJunkies.Models.Console;
using System.Collections.Generic;

namespace GameJunkies.Contracts
{
    public interface IConsoleService
    {
        bool CreateConsole(ConsoleCreate model);
        bool DeleteConsole(int consoleId);
        ConsoleDetail GetConsoleById(int id);
        IEnumerable<ConsoleListItem> GetConsoles();
        bool UpdateConsole(ConsoleEdit model);
    }
}