using System;
using System.Collections.Generic;
using System.Data;
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

            string procedureName = "[dbo].[ADD_PLAYER]";
            string procedure_AddGame="[dbo].[ADD_GAME]";
            SqlConnection connection = new SqlConnection(this.connnectionString);
            connection.Open();
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@name", playerchoice.name));
                command.ExecuteNonQuery();
            }
              using (SqlCommand command = new SqlCommand(procedure_AddGame, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserName", playerchoice.name));
                command.Parameters.Add(new SqlParameter("@GameStarted", DateTime.Now.ToString("MM/dd/yyyy HH:mm")));
                command.Parameters.Add(new SqlParameter("@GameResult", gameresult.result));
                command.Parameters.Add(new SqlParameter("@NumOfTurns", playerchoice.numberofrounds));
                command.ExecuteNonQuery();
            }
            return gameresult;
        }


    }
    // [HttpGet("leaderboard")]
    // public Leaderboard getleaderboard()
    // {


    //    return this.g1.GetAllresult();

    // }



}

