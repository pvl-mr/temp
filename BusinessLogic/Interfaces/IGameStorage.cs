using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IGameStorage
    {
        List<GameViewModel> GetFullList();

        List<GameViewModel> GetFilteredList(GameBindingModel model);

        GameViewModel GetElement(GameBindingModel model);

        void Insert(GameBindingModel model);

        void Update(GameBindingModel model);

        void Delete(GameBindingModel model);
    }
}
