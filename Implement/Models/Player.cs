using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Implement.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int? GameId { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public PlayerType Type { get; set; }
        [Required]
        public string Nickname { get; set; }
        public DateTime DateDeath { get; set; }
        public virtual Game Game { get; set; }
    }
}
