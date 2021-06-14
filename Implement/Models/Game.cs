using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Implement.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string GameName { get; set; }

        [Required]
        public string MasterName { get; set; }

        [Required]
        public DateTime DateGame { get; set; }

        [ForeignKey("GameId")]
        public List<Player> Players { get; set; }
    }
}
