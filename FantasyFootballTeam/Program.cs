using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FantasyFootballTeam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var players = LoadJson();

            Console.WriteLine($"{players.Count}");
        }

        public static List<Player> LoadJson()
        {
            List<Player> players;
            using (StreamReader r = new StreamReader(@"C:\Development\FantasyFootball\PlayersComplete.json"))
            {
                string json = r.ReadToEnd();
                players = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            return players;
        }
    }
}
