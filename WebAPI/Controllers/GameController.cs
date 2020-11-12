using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        Player p1 = new Player();
        Game g1 = new Game();
        resultlist resultlist = new resultlist();

        [HttpPost("result")]
        public resultlist Result([FromBody] Player player)
        {
            resultlist = this.g1.getResult(player);
            return resultlist;

        }

        [HttpGet("leaderboard")]
        public Leaderboard getleaderboard()
        {
           

           return this.g1.GetAllresult();

        }



    }
}
