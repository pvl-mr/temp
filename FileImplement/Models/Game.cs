using System;
using System.Collections.Generic;
using System.Text;

namespace FileImplement.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string GameName { get; set; }

        public string MasterName { get; set; }

        public DateTime DateGame { get; set; }

        public List<Player> Players { get; set; }
    }
}
