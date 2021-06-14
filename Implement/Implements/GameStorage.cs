using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using Implement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Implement.Implements
{
    public class GameStorage : IGameStorage
    {
        public List<GameViewModel> GetFullList()
        {
            using (var context = new Database())
            {
                return context.Games.Select(rec => new GameViewModel
                {
                    Id = rec.Id,
                    GameName = rec.GameName,
                    DateGame = rec.DateGame,
                    MasterName = rec.MasterName
                })
                .ToList();
            }
        }

        public List<GameViewModel> GetFilteredList(GameBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Database())
            {
                return context.Games.Include(x => x.Players)
                .Where(rec => rec.GameName == model.GameName)
                .Select(rec => new GameViewModel
                {
                    Id = rec.Id,
                    GameName = rec.GameName,
                    DateGame = rec.DateGame,
                    MasterName = rec.MasterName,
                    GamePlayers = rec.Players
                    .ToDictionary(recPC => recPC.Id, recPC =>recPC.Nickname)
                })
                .ToList();
            }
        }

        public GameViewModel GetElement(GameBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Database())
            {
                var game = context.Games.Include(x => x.Players)
                .FirstOrDefault(rec => rec.GameName == model.GameName || rec.Id == model.Id);
                return game != null ?
                new GameViewModel
                {
                    Id = game.Id,
                    GameName = game.GameName,
                    DateGame = game.DateGame,
                    MasterName = game.MasterName,
                    GamePlayers = game.Players
                    .ToDictionary(recPC => recPC.Id, recPC => recPC.Nickname)
                } :
                null;
            }
        }

        public void Insert(GameBindingModel model)
        {
            using (var context = new Database())
            {
                context.Games.Add(CreateModel(model, new Game()));
                context.SaveChanges();
            }
        }

        public void Update(GameBindingModel model)
        {
            using (var context = new Database())
            {
                var element = context.Games.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Игра не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(GameBindingModel model)
        {
            using (var context = new Database())
            {
                Game element = context.Games.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Games.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Игра не найдена");
                }
            }
        }

        private Game CreateModel(GameBindingModel model, Game game)
        {
            game.GameName = model.GameName;
            game.DateGame = model.DateGame;
            game.MasterName = model.MasterName;
            return game;
        }
    }
}
