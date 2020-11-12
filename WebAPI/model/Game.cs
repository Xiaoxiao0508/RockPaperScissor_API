using System;
using System.Collections.Generic;

namespace WebAPI.model
{
    public class Game
    {
        public Player Player { get; set; }
        public string Result { get; set; }
        List<string> selectionlist = new List<string>();
        resultlist resultlist = new resultlist();

        Allresult allresult = new Allresult();
        int turnsplayed = 1;
        int gamewin = 1;



        public Game(Player player, string result)
        {
            this.Player = player;
            this.Result = result;
        }

        public Game()
        {
        }
        public resultlist getResult(Player p1)

        {
            List<resultlist> r1 = new List<resultlist>();
            turnsplayed++;
            selectionlist.Add("rock");
            selectionlist.Add("paper");
            selectionlist.Add("scissor");

            Random rand = new Random();
            int index = rand.Next(selectionlist.Count);
            string sysselection = selectionlist[index];
            Player sys = new Player("admin", sysselection);
            Game g1 = new Game();
            if (p1.Choice == sysselection)
            {
                this.Result = "draw";
            }
            else if ((p1.Choice == "rock" && sysselection == "scissor") || (p1.Choice == "paper" && sysselection == "rock") || (p1.Choice == "scissor" && sysselection == "paper"))
            {
                this.Result = "win";
                gamewin++;
            }
            else
            {
                this.Result = "lose";
            }
            resultlist.playername = p1.Name;
            resultlist.playerchoice = p1.Choice;
            resultlist.syschoice = sysselection;
            resultlist.result = this.Result;
            resultlist.turnsplayed = turnsplayed;
            resultlist.gamewin = gamewin;
            resultlist.winratio = gamewin / turnsplayed;
            r1.Add(resultlist);
            allresult.allresultdetail = r1;
            return resultlist;
        }
        public Leaderboard GetAllresult()

        {
            Leaderboard leaderboard = new Leaderboard();
            Leaderboardline leaderboardline = new Leaderboardline();
            leaderboardline.Name = this.resultlist.playername;
            leaderboardline.Turnsplayed = this.resultlist.turnsplayed;
            leaderboardline.Winratio = this.resultlist.winratio;
            List<Leaderboardline> l1 = new List<Leaderboardline>();
            l1.Add(leaderboardline);
            leaderboard.Leaderboardlist = l1;
            return leaderboard;
        }

    }


}






