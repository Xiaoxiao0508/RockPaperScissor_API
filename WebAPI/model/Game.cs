using System;
using System.Collections.Generic;

namespace WebAPI.model
{
    public class Game
    {
        public Player Player { get; set; }
        public string Result { get; set; }
        List<string> selectionlist = new List<string>();
        // roundresult roundresult = new roundresult();

        Gameresult gameresult = new Gameresult();
        int turnsplayed = 1;
        public Game(Player player, string result)
        {
            this.Player = player;
            this.Result = result;
            selectionlist.Add("rock");
            selectionlist.Add("paper");
            selectionlist.Add("scissor");

        }

        public Game()
        {
            selectionlist.Add("rock");
            selectionlist.Add("paper");
            selectionlist.Add("scissor");
        }
        public roundresult GetRoundResult(string playerchoice)

        {
            turnsplayed++;
            Random rand = new Random();
            int index = rand.Next(selectionlist.Count);
            string sysselection = selectionlist[index];
            Player sys = new Player("admin", sysselection);
            if (playerchoice == sysselection)
            {
                this.Result = "draw";
            }
            else if ((playerchoice == "rock" && sysselection == "scissor") || (playerchoice == "paper" && sysselection == "rock") || (playerchoice == "scissor" && sysselection == "paper"))
            {
                this.Result = "win";
            }
            else
            {
                this.Result = "lose";
            }

            roundresult roundresult = new roundresult();

            roundresult.playerchoice = playerchoice;
            roundresult.syschoice = sysselection;
            roundresult.resultofround = this.Result;


            return roundresult;
        }

        public Gameresult GetGameresult(Playerchoice playerchoice)

        {
            List<roundresult> allresult = new List<roundresult>();
            int roundwins = 0;
            int rounddraw=0;
            int roundlose=0;
            foreach (string choice in playerchoice.choices)
            {
                roundresult r=this.GetRoundResult(choice);
                allresult.Add(r);
            }
           
            gameresult.allresult = allresult;

            foreach (var result in allresult)
            {
                if (result.resultofround == "win")
                {
                    roundwins++;
                }
                  if (result.resultofround == "lose")
                {
                    roundlose++;
                }
                 if (result.resultofround == "draw")
                {
                    rounddraw++;
                }

            }
    
            if (roundwins > playerchoice.numberofrounds / 2)
            {
                this.gameresult.result = "win";
            }
             else if (roundlose > playerchoice.numberofrounds / 2)
            {
                this.gameresult.result = "lose";
            }
            else
            {
                this.gameresult.result = "draw";
            }

            return gameresult;
        }
     

    }


}






