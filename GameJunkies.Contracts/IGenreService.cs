using GameJunkies.Models.Genre;
using System.Collections.Generic;

namespace GameJunkies.Contracts
{
    public interface IGenreService
    {
        bool CreateGenre(GenreCreate model);
        bool DeleteGenre(int genreId);
        GenreDetail GetGenreById(int id);
        IEnumerable<GenreListItem> GetGenres();
        bool UpdateGenre(GenreEdit model);
    }
}