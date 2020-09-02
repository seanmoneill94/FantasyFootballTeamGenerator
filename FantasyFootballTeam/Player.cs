using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFootballTeam
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Team { get; set; }
        public Position Position { get; set; }
        public string Available { get; set; }
        public decimal Price { get; set; }
        public string Uncertainty { get; set; }
        public string OverallPoints { get; set; }
        public string Week1 { get; set; }
        public string Week2 { get; set; }
        public string Week3 { get; set; }
        public string Week4 { get; set; }
        public string Week5 { get; set; }
        public string Week6 { get; set; }
    }

    public class Team {

        public string TeamName { get; set; }
        public List<Player> Players {get; set;}

        public List<Player> GetPlayersByPosition(Position position) {
            return Players.Where(p => p.Position == position).ToList();
        }
    }

    public enum Position {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward,
    }

    public class Squad {

        public Squad(int gk, int def, int mid, int fwd) {
            GoalkeeperCount = gk;
            DefenderCount = def;
            MidfielderCount = mid;
            ForwardCount = fwd;
        }

        public readonly int GoalkeeperCount;
        public readonly int DefenderCount;
        public readonly int MidfielderCount;
        public readonly int ForwardCount;

        public List<Player> Goalkeepers;
        public List<Player> Defenders;
        public List<Player> Midfielders;
        public List<Player> Forwards;

        public bool CanAddPlayer(Position position) {
            switch (position) {
                case Position.Goalkeeper:
                    return Goalkeepers.Count < GoalkeeperCount;
                case Position.Defender:
                    return Defenders.Count < DefenderCount;
                case Position.Midfielder:
                    return Midfielders.Count < MidfielderCount;
                case Position.Forward:
                    return Forwards.Count < ForwardCount;
                default:
                    return false;
            }
        }

        public void AddPlayer(Position position, Player player)
        {
            switch (position)
            {
                case Position.Goalkeeper:
                    Goalkeepers.Add(player);
                    break;
                case Position.Defender:
                    Defenders.Add(player);
                    break;
                case Position.Midfielder:
                    Midfielders.Add(player);
                    break;
                case Position.Forward:
                    Forwards.Add(player);
                    break;
            }
        }
    }
}