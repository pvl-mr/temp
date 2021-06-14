using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessLogic.BindingModels
{
    public class PlayerBindingModel
    {
        public int? Id { get; set; }
        public int? GameId { get; set; }
        public string Nickname { get; set; }
        public PlayerType Type { get; set; }
        public DateTime DateDeath { get; set; }
        public int Score { get; set; }
    }
}
