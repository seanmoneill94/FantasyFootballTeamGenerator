using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace FantasyFootballTeam
{
    public class Program
    {
        private const float Money = 100;
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var players = LoadJson();
            var teams = GetTeams(players);


            Console.WriteLine($"{players.Count}");

            var squad = new Squad(2, 5, 5, 3);
        }

        public static List<Player> LoadJson()
        {
            List<Player> players;
            using (StreamReader r = new StreamReader(@"C:\Development\FantasyFootball\FantasyFootballTeam\PlayersComplete.json"))
            {
                string json = r.ReadToEnd();
                players = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            return players;
        }


        private static List<Team> GetTeams(List<Player> allPlayers) {
            var teams = new List<Team>();

            foreach (var player in allPlayers) {
                if (teams.Any(t => t.TeamName == player.Team))
                {
                    teams.First(t => t.TeamName == player.Team).Players.Add(player);
                }
                else {
                    teams.Add(new Team()
                    {
                        TeamName = player.Team,
                        Players = new List<Player>() { player }
                    });
                }
            
            
            }


            return null;
        }

        /*
        private Player SelectCheapestWithMostPoints(Players players) { 
            players.
            
        }
        */
    }
}
