using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Dto
{
    public class JsonBasketballDto
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime StartTime { get; set; }
        public string Location { get; set; }
        public int ResultHome { get; set; }
        public int ResultAway { get; set; }

        public int FoulsHome { get; set; }
        public int FoulsAway { get; set; }
        public int ThreePointMadeHome { get; set; }
        public int ThreePointMadeAway { get; set; }
    }
}
