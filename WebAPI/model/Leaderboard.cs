using System;
using System.Collections.Generic;

namespace WebAPI.model
{
    public class Leaderboard
    {
        public List<Leaderboardline>  Leaderboardlist { get; set; }


         public Leaderboard()
        {
        }

        public Leaderboard(List<Leaderboardline> leaderboardlist)
        {
            Leaderboardlist = leaderboardlist;
        }
    
        
    }
}
