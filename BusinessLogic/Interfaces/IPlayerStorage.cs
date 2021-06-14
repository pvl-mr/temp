using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IPlayerStorage
    {
        List<PlayerViewModel> GetFullList();
        List<PlayerViewModel> GetFilteredList(PlayerBindingModel model);
        PlayerViewModel GetElement(PlayerBindingModel model);
        void Insert(PlayerBindingModel model);
        void Update(PlayerBindingModel model);
        void Delete(PlayerBindingModel model);
    }
}
