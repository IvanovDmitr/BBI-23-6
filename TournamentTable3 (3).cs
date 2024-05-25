using System;
using System.Collections.Generic;

namespace ЛР_10_1
{
    public partial class TournamentTable
    {
        public void Disqual(Team team)
        {
            Teams.Remove(team);
        }
    }
}
