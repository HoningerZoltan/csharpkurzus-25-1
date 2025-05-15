using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Dto
{
    public class JsonHockeyDto
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime StartTime { get; set; }
        public string Location { get; set; }
        public int ResultHome { get; set; }
        public int ResultAway { get; set; }

        public int PenaltyMinutesHome { get; set; }
        public int PenaltyMinutesAway { get; set; }
        public int ShotsOnGoalHome { get; set; }
        public int ShotsOnGoalAway { get; set; }
    }
}
