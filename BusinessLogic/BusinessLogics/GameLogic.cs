using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogics
{
    public class GameLogic
    {
        private readonly IGameStorage _gameStorage;
        public GameLogic(IGameStorage gameStorage)
        {
            _gameStorage = gameStorage;
        }
        public List<GameViewModel> Read(GameBindingModel model)
        {
            if (model == null)
            {
                return _gameStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GameViewModel> { _gameStorage.GetElement(model) };
            }
            return _gameStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(GameBindingModel model)
        {
            var element = _gameStorage.GetElement(new GameBindingModel
            {
                GameName = model.GameName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть игра с таким названием");
            }
            if (model.Id.HasValue)
            {
                _gameStorage.Update(model);
            }
            else
            {
                _gameStorage.Insert(model);
            }
        }
        public void Delete(GameBindingModel model)
        {
            var element = _gameStorage.GetElement(new GameBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Игра не найдена");
            }
            _gameStorage.Delete(model);
        }
    }
}

