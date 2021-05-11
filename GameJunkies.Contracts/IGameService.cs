using GameJunkies.Models.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameJunkies.Contracts
{
    public interface IGameService
    {
        bool CreateGame(GameCreate model);
        bool DeleteGame(int gameId);
        GameDetail GetGameById(int id);
        GameEdit GetGameEditById(int id);
        IEnumerable<GameListItem> GetGames();
        Task<IEnumerable<GameCard>> RandomGames(int numberOfGames = 5);
        bool UpdateGame(GameEdit model);
    }
}