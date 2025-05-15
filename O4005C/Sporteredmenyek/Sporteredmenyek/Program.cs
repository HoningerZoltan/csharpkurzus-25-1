using Spectre.Console;
using Sporteredmenyek.Core.Models;
using Sporteredmenyek.UI;

namespace Sporteredmenyek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UiPrinter ui = new UiPrinter();
            int menuValue = 0;

            //Teszt--------------------------------------------------------
            var hockeyMatch = new HockeyMatch(
                homeTeam: "Fradi",
                awayTeam: "Újpest",
                start_time: new DateTime(2025, 4, 29, 18, 30, 0),
                location: "MVM Dome",
                result: new TeamsIntValuePair(3, 3),
                penaltyMinutes: new TeamsIntValuePair(6, 8),
                shotsOnGoal: new TeamsIntValuePair(25, 30)
            );
            var footballMatch = new FootballMatch(
                    homeTeam: "Real Madrid",
                    awayTeam: "Manchester City",
                    start_time: new DateTime(2025, 5, 15, 20, 45, 0),
                    location: "Santiago Bernabéu, Madrid",
                    result: new TeamsIntValuePair(1, 2),
                    redCards: new TeamsIntValuePair(0, 1),
                    yellowCards: new TeamsIntValuePair(2, 3),
                    corners: new TeamsIntValuePair(5, 7)
                );
            var basketballMatch = new BasketballMatch(
                homeTeam: "Los Angeles Lakers",
                awayTeam: "Chicago Bulls",
                startTime: new DateTime(2025, 4, 28, 19, 30, 0),
                location: "Crypto.com Arena, Los Angeles",
                result: new TeamsIntValuePair(102, 98),
                fouls: new TeamsIntValuePair(18, 20),
                threePointMade: new TeamsIntValuePair(12, 9)
            );

            //----------------------------------------------------------

            ui.ClearConsole();
            ui.MainLoop();
            
        }
    }
}
