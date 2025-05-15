using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Dto
{
    public class JsonFootballDto
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime StartTime { get; set; }
        public string Location { get; set; }
        public int ResultHome { get; set; }
        public int ResultAway { get; set; }


        public int RedCardsHome { get; set; }
        public int RedCardAway { get; set; }
        public int YellowCardsHome { get; set; }
        public int YellowCardAway { get; set; }
        public int CornersHome { get; set; }
        public int CornersAway { get; set; }
        


    }
}
