using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebAPI.model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        // Player p1 = new Player();
        Game g1 = new Game();
        Gameresult gameresult = new Gameresult();
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        IConfiguration configuration;
        string connnectionString = "";
        public GameController(IConfiguration iConfig)
        {
            this.configuration = iConfig;
            this.connnectionString = this.configuration.GetSection("DbConnectionString").Value;
            // use the sqlconnecitonStringBuilder to create connection string
            this.stringBuilder.DataSource = this.configuration.GetSection("Connection").GetSection("DataSource").Value;
            this.stringBuilder.InitialCatalog = this.configuration.GetSection("Connection").GetSection("InitialCatalog").Value;
            this.stringBuilder.UserID = this.configuration.GetSection("Connection").GetSection("ID").Value;
            this.stringBuilder.Password = this.configuration.GetSection("Connection").GetSection("Password").Value;
            this.connnectionString = stringBuilder.ConnectionString;
        }

        [HttpPost("result")]
        public Gameresult Result([FromBody] Playerchoice playerchoice)
        {

            gameresult = this.g1.GetGameresult(playerchoice);

            //  string connectionString = @"Data Source=database-2.cckjgcdoazf1.us-east-1.rds.amazonaws.com;Initial Catalog=test;User ID=admin;Password=Kangcerking1";
            SqlConnection connection = new SqlConnection(this.connnectionString);
            string querystring = "Insert into Player(Username)Values('" + playerchoice.name + "')";
            SqlCommand command = new SqlCommand(querystring, connection);
            var adapter = new SqlDataAdapter();
            connection.Open();
            adapter.InsertCommand = new SqlCommand(querystring, connection);
            adapter.InsertCommand.ExecuteNonQuery();
            return gameresult;

        }

        // [HttpGet("leaderboard")]
        // public Leaderboard getleaderboard()
        // {


        //    return this.g1.GetAllresult();

        // }



    }
}
