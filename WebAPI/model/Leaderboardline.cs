using System;
using System.Collections.Generic;

namespace WebAPI.model
{
    public class Leaderboardline
    {
      

        public string Name { get; set; }
        public int winratio { get; set; }
        public int gameplayed{ get; set; }
        public string LastFive{get;set;}
          public Leaderboardline()
        {
        }

       
    }
}
