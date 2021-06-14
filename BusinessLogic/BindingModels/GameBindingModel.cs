using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BindingModels
{
    public class GameBindingModel
    {
        public int? Id { get; set; }
        public string GameName { get; set; }
        public string MasterName { get; set; }
        public DateTime DateGame { get; set; }
        public Dictionary<int, string> GamePlayers { get; set; }
    }
}
