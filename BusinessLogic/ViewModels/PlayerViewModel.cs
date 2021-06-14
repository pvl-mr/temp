using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }

        [DisplayName("Название игры")]
        public string GameName { get; set; }
        [DisplayName("Ник")]
        public string Nickname { get; set; }
        [DisplayName("Тип игрока")]
        public PlayerType Type { get; set; }
        [DisplayName("Дата смерти")]
        public DateTime DateDeath { get; set; }
        [DisplayName("Очки игрока")]
        public int Score { get; set; }
    }
}
