using System;

namespace WebAPI.model
{
    public class resultlist
    {
        public resultlist()
        {
        }

        public resultlist(string playername, string playerchoice, string syschoice, string result, int turnsplayed, int gamewin, int winratio)
        {
            this.playername = playername;
            this.playerchoice = playerchoice;
            this.syschoice = syschoice;
            this.result = result;
            this.turnsplayed = turnsplayed;
            this.gamewin = gamewin;
            this.winratio = winratio;
        }

        public string playername { get; set; }
        public string playerchoice { get; set; }
        public string syschoice { get; set; }
        public string result { get; set; }
        public int turnsplayed { get; set; }
        public int gamewin { get; set; }
        public int winratio { get; set; }


    }
}
