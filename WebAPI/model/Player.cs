using System;

namespace WebAPI.model
{
    public class Player
    {


        public string Name { get; set; }
        public string Choice { get; set; }

        public Player(string name, string choice)
        {
            this.Name = name;
            this.Choice = choice;
        }

        public Player()
        {
        }
       
    }
}
