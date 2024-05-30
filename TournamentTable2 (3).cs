using System;
using System.Collections.Generic;

namespace ЛР_10_1
{
    public partial class TournamentTable
    {
        public Team GetBest()
        {
            Teams.Sort((x, y) => y.CalculatePoints().CompareTo(x.CalculatePoints()));
            return Teams[0];
        }

        public List<Team> GetBest(int n)
        {
            Teams.Sort((x, y) => y.CalculatePoints().CompareTo(x.CalculatePoints()));
            return Teams.GetRange(0, Math.Min(n, Teams.Count));
        }
    }
}
