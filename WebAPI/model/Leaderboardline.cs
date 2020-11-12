using System;

namespace WebAPI.model
{
    public class Leaderboardline
    {
      

        public string Name { get; set; }
        public int Turnsplayed { get; set; }
        public int Winratio { get; set; }
          public Leaderboardline()
        {
        }

        public Leaderboardline(string name, int turnsplayed, int winratio)
        {
            Name = name;
            Turnsplayed = turnsplayed;
            Winratio = winratio;
        }
    }
}
