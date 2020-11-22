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
            // use the sqlconnecitonStringBuilder to create connectionstring
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


            string procedure_AddGame = "[dbo].[ADD_GAME]";
            SqlConnection connection = new SqlConnection(this.connnectionString);
            connection.Open();
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



        [HttpGet("leaderboard")]
        public Leaderboard getleaderboard()
        {
            Leaderboard leaderboard = new Leaderboard();
            List<Leaderboardline> leaderboardlinelist=new List<Leaderboardline>();
            Leaderboardline leaderboardline = new Leaderboardline();
            SqlConnection conn = new SqlConnection(this.connnectionString);
            conn.Open();
            string querystring =@"SELECT G.UserName, (W.gameswin/G.gamesplayed) as winratio, G.gamesplayed, L.lastfive
FROM
  (SELECT COUNT(UserName) as gamesplayed, UserName
  FROM Game
  GROUP BY UserName)  G
  LEFT JOIN
  (SELECT UserName, COUNT(*) AS gameswin
  FROM Game
  WHERE GameResult='W'
  GROUP BY UserName)  W
  ON
  G.UserName=W.UserName
  LEFT JOIN
  (SELECT UserName, LEFT(STRING_AGG(GameResult,'' ) WITHIN GROUP(ORDER BY GameStarted DESC),5) AS lastfive
  FROM Game
  Group by UserName) L
  ON W.UserName=L.UserName
  ORDER BY winratio DESC";
            SqlCommand command = new SqlCommand(querystring, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                { 
                   
                    leaderboardlinelist.Add(
                        new Leaderboardline() { name=reader[0].ToString(), winratio =Convert.IsDBNull(reader[1])?0:(int)reader[1], gamesplayed = (int)reader[2], lastfive= reader[3].ToString() });
                        leaderboard.leaderboardlist=leaderboardlinelist;
                }
            }


            return leaderboard;

        }
    }



}

