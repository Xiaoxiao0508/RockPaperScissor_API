using System;
using System.Collections.Generic;

namespace WebAPI.model
{
    public class Gameresult
    {
        public Gameresult()
        {
        }

        public string result { get; set; }
        public List<roundresult> allresult { get; set; }
    }
}
