using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using Implement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implement.Implements
{
    public class PlayerStorage : IPlayerStorage
    {
        public List<PlayerViewModel> GetFullList()
        {
            using (var context = new Database())
            {
                return context.Players
                .Include(rec => rec.Game)
                .Select(rec => new PlayerViewModel
                {
                    Id = rec.Id,
                    Score = rec.Score,
                    Type = rec.Type,
                    Nickname = rec.Nickname,
                    DateDeath = rec.DateDeath,
                    GameId = rec.GameId,
                    GameName = rec.Game.GameName
                })
                .ToList();
            }
        }


        public List<PlayerViewModel> GetFilteredList(PlayerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Database())
            {
                return context.Players
                .Include(rec => rec.Game)
                .Where(rec => model.GameId.HasValue && rec.GameId == model.GameId)
                .Select(rec => new PlayerViewModel
                {
                    Id = rec.Id,
                    Score = rec.Score,
                    Type = rec.Type,
                    Nickname = rec.Nickname,
                    DateDeath = rec.DateDeath,
                    GameId = rec.GameId,
                    GameName = rec.Game.GameName
                })
                .ToList();
            }
        }

        public PlayerViewModel GetElement(PlayerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Database())
            {
                var player = context.Players
                .Include(rec => rec.Game)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return player != null ?
                new PlayerViewModel
                {
                    Id = player.Id,
                    Score = player.Score,
                    Type = player.Type,
                    Nickname = player.Nickname,
                    DateDeath = player.DateDeath,
                    GameId = player.GameId,
                    GameName = player.Game.GameName
                } :
                null;
            }
        }

        public void Insert(PlayerBindingModel model)
        {
            using (var context = new Database())
            {
                context.Players.Add(CreateModel(model, new Player()));
                context.SaveChanges();
            }
        }

        public void Update(PlayerBindingModel model)
        {
            using (var context = new Database())
            {
                var element = context.Players.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(PlayerBindingModel model)
        {
            using (var context = new Database())
            {
                Player element = context.Players.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Players.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Player CreateModel(PlayerBindingModel model, Player player)
        {
            player.Score = model.Score;
            player.Nickname = model.Nickname;
            player.DateDeath = model.DateDeath;
            player.Type = model.Type;
            player.GameId = model.GameId.Value;
            return player;
        }
    }
}
