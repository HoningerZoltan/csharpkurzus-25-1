using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    public record BasketballMatch : Match
    {
        public override int PeriodsNumber { get; } = 4;

        public TeamsIntValuePair Fouls { get; init; }
        public TeamsIntValuePair ThreePointMade { get; init; }

        public BasketballMatch(
            string homeTeam,
            string awayTeam,
            DateTime startTime,
            string location,
            TeamsIntValuePair result,
            TeamsIntValuePair fouls,
            TeamsIntValuePair threePointMade
        ) : base(homeTeam, awayTeam, startTime, location, result)
        {
            Fouls = fouls;
            ThreePointMade = threePointMade;
        }

        public override void Print()
        {
            var kozos = new Table();
            kozos.Width(80);
            kozos.Border(TableBorder.None);
            kozos.AddColumn(new TableColumn(new Markup("[bold]----------------------------- Kosárlabda -----------------------------[/]")).Centered()).Centered();

            kozos.AddRow(new Markup($"[white]Időpont: {StartTime.ToShortTimeString()}[/]").Centered());
            kozos.AddRow(new Markup($"[white]Helyszín: {Location}[/]").Centered());



            var table = new Table();
            table.Border(TableBorder.Rounded);
            table.Width(80);
            table.AddColumn("").Centered();
            table.AddColumn("Hazai csapat").Centered();
            table.AddColumn("Vendég csapat").Centered();


            table.AddRow("Név:", HomeTeam, AwayTeam);
            table.AddRow("Eredmény:", Result.Home.ToString(), Result.Away.ToString());
            table.AddRow("Szabálytalanságok:", Fouls.Home.ToString(), Fouls.Away.ToString());
            table.AddRow("Hárompontosok:", ThreePointMade.Home.ToString() + " db", ThreePointMade.Away.ToString() + " db");



            AnsiConsole.Write(kozos);
            AnsiConsole.Write(table);
            Console.WriteLine("\n\n");
        }
    }
}
