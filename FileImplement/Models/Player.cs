using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileImplement.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Score { get; set; }
        public PlayerType Type { get; set; }
        public string Nickname { get; set; }
        public DateTime DateDeath { get; set; }
        public virtual Game Game { get; set; }
    }
}
