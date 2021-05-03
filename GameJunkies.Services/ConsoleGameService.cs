using GameJunkies.Data;
using GameJunkies.Models.ConsoleGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Services
{
    public class ConsoleGameService
    {
        public bool CreateConsoleGame(ConsoleGameCreate model)
        {
            var entity = new ConsoleGame()
            {
                ConsoleId = model.ConsoleId,
                GameId = model.GameId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ConsoleGames.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteConsoleGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.ConsoleGames.Single(e => e.Id == id);
                    ctx.ConsoleGames.Remove(entity);
                    return ctx.SaveChanges() >= 1;
                }
                catch (Exception e)
                {
                    Debug.Print("Exception thrown while looking for consolegame");
                    Debug.Print(e.Message);
                    return false;
                    throw;
                }
            }
        }
    }
}
