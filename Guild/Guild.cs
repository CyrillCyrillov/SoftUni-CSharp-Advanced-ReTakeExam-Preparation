using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        List<Player> players;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            players = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => players.Count;}

        public void AddPlayer(Player player)
        {
            if(players.Count < Capacity)
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = players.FirstOrDefault(n => n.Name == name);
            if(playerToRemove != null)
            {
                players.Remove(playerToRemove);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = players.FirstOrDefault(n => n.Name == name);
            if(playerToPromote != null && playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToDemote = players.FirstOrDefault(n => n.Name == name);
            if (playerToDemote != null && playerToDemote.Rank != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            Player[] result = players.Where(n=> n.Class == "clas").ToArray();
            players.RemoveAll(n => n.Class == "clas");

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString();
            

        }
    }
}
