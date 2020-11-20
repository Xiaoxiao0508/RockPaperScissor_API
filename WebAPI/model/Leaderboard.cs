using System;
using System.Collections.Generic;

namespace WebAPI.model
{
    public class Leaderboard
    {
        public List<Leaderboardline>  leaderboardlist { get; set; }


         public Leaderboard()
        {
        }

        public Leaderboard(List<Leaderboardline> Leaderboardlist)
        {
            leaderboardlist = Leaderboardlist;
        }
    
        
    }
}
