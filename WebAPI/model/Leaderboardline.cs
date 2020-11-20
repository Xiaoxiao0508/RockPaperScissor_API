using System;
using System.Collections.Generic;

namespace WebAPI.model
{
    public class Leaderboardline
    {
      

        public string name { get; set; }
        public int winratio { get; set; }
        public int gamesplayed{ get; set; }
        public string lastfive{get;set;}
          public Leaderboardline()
        {
        }

       
    }
}
