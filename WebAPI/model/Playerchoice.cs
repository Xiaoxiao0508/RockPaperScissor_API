using System;
using System.Collections.Generic;

namespace WebAPI.model
{
    public class Playerchoice
    {
        public Playerchoice()
        {
        }

        public string name { get; set; }
        public int numberofrounds { get; set; }
        public List<string> choices { get; set; }
    }
}
