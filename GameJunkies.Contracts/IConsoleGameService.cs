using GameJunkies.Models.ConsoleGame;

namespace GameJunkies.Contracts
{
    public interface IConsoleGameService
    {
        bool CreateConsoleGame(ConsoleGameCreate model);
        bool CreateConsoleGames(ConsoleGamesCreates model);
        bool DeleteConsoleGame(int id);
        ConsoleGamesCreates GetCreateLink(int id);
    }
}