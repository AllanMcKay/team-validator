using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
        }
        public List<Player> Players{get;set;}
    }
}
