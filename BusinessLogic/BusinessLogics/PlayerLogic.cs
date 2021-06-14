using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogics
{
    public class PlayerLogic
    {
        private readonly IPlayerStorage _playerStorage;
        public PlayerLogic(IPlayerStorage playerStorage)
        {
            _playerStorage = playerStorage;
        }
        public List<PlayerViewModel> Read(PlayerBindingModel model)
        {
            if (model == null)
            {
                return _playerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PlayerViewModel> { _playerStorage.GetElement(model) };
            }
            return _playerStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PlayerBindingModel model)
        {
            var element = _playerStorage.GetElement(new PlayerBindingModel { Nickname = model.Nickname });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть игрок с таким никнеймом");
            }
            if (model.Id.HasValue)
            {
                _playerStorage.Update(model);
            }
            else
            {
                _playerStorage.Insert(model);
            }
        }
        public void Delete(PlayerBindingModel model)
        {
            var element = _playerStorage.GetElement(new PlayerBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _playerStorage.Delete(model);
        }
    }
}
