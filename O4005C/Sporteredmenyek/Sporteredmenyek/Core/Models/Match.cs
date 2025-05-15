using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    public abstract record Match(
        string HomeTeam,
        string AwayTeam,
        DateTime StartTime,
        string Location,
        TeamsIntValuePair Result
    )
    {
        
        public abstract int PeriodsNumber { get; }
        public abstract void Print();
    }


}
