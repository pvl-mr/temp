using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название игры")]
        public string GameName { get; set; }
        [DisplayName("Ведущий")]
        public string MasterName { get; set; }
        [DisplayName("Дата проведения")]
        public DateTime DateGame { get; set; }

        public Dictionary<int, string> GamePlayers { get; set; }
    }
}
