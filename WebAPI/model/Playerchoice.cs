using System;

namespace WebAPI.model
{
    public class Playerchoice
    {
      

        public string playerchoice { get; set; }
          public Playerchoice(string playerchoice)
        {
            this.playerchoice = playerchoice;
        }

        public Playerchoice()
        {
        }
    }
}
