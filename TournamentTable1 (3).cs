using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ЛР_10_1
{
    public partial class TournamentTable : ITable
    {
        public string Name { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();

        public TournamentTable() { }  

        public TournamentTable(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string info = $"Tournament: {Name}\nTeams:\n";
            foreach (var team in Teams)
            {
                info += team.ToString() + "\n";
            }
            return info;
        }

        public void AddMatch(Team team1, Team team2)
        {
            Random random = new Random();
            int result = random.Next(3); 
            if (result == 0)
            {
                team1.Draws++;
                team2.Draws++;
            }
            else if (result == 1)
            {
                team1.Wins++;
                team2.Losses++;
            }
            else
            {
                team1.Losses++;
                team2.Wins++;
            }
        }

        public void Sort(string criteria)
        {
            if (criteria == "points")
            {
                Teams.Sort((x, y) => y.CalculatePoints().CompareTo(x.CalculatePoints()));
            }
            else if (criteria == "name")
            {
                Teams.Sort((x, y) => x.Name.CompareTo(y.Name));
            }
        }

        public void Sort(int dummy)
        {
            if (dummy == 0)
            {
                Teams.Sort((x, y) => y.CalculatePoints().CompareTo(x.CalculatePoints()));
            }
            else
            {
                Teams.Sort((x, y) => x.Name.CompareTo(y.Name));
            }
        }
    }
}
