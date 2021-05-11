using GameJunkies.Contracts;
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
    public class ConsoleGameService : IConsoleGameService
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
        //public bool CreateConsoleGames(IEnumerable<ConsoleGameCreate> consoles)
        //{
        //    bool succeeded = true;
        //    foreach (var console in consoles)
        //    {
        //        if (console.isIncluded)
        //        {
        //            if (!CreateConsoleGame(console)) { succeeded = false; break; }
        //        }
        //    }
        //    return succeeded;
        //}
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
        public ConsoleGamesCreates GetCreateLink(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model = new ConsoleGamesCreates();
                model.GameId = id;
                var query = ctx.Consoles.Select(e => new ConsoleChoiceItem { ConsoleName = e.Name, ConsoleId = e.Id, isLinked = false });
                model.ConsoleList = query.ToList();
                return model;
            }
        }
        public bool CreateConsoleGames(ConsoleGamesCreates model)
        {
            var recordList = new List<ConsoleGame>();
            foreach (var choice in model.ConsoleList)
            {
                if (choice.isLinked)
                {
                    var newEntity = new ConsoleGame() { ConsoleId = choice.ConsoleId, GameId = model.GameId };
                    recordList.Add(newEntity);
                }
            }
            using (var ctx = new ApplicationDbContext())
            {
                foreach (var consoleGame in recordList)
                {
                    ctx.ConsoleGames.Add(consoleGame);
                }
                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
