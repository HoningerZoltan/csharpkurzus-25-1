using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    public record FootballMatch : Match
    {
        public override int PeriodsNumber { get; } = 2;

        public TeamsIntValuePair RedCards { get; init; }
        public TeamsIntValuePair YellowCards { get; init; }
        public TeamsIntValuePair Corners { get; init; }
        public FootballMatch(
            string homeTeam,
            string awayTeam, 
            DateTime start_time,
            string location,
            TeamsIntValuePair result, 
            TeamsIntValuePair redCards, 
            TeamsIntValuePair yellowCards, 
            TeamsIntValuePair corners
        ) : base(homeTeam, awayTeam, start_time, location, result)
        {
            RedCards = redCards;
            YellowCards = yellowCards;
            Corners = corners;
        }
        public override void Print()
        {
            var kozos = new Table();
            kozos.Width(80);
            kozos.Border(TableBorder.None);
            kozos.AddColumn(new TableColumn(new Markup("[bold]----------------------------- Labdarúgás -----------------------------[/]")).Centered()).Centered();

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
            table.AddRow("Szögletek:", Corners.Home.ToString(), Corners.Away.ToString());
            table.AddRow("Sárga lapok:", YellowCards.Home.ToString() + " db", YellowCards.Away.ToString() + " db");
            table.AddRow("Piros lapok:", RedCards.Home.ToString() + " db", RedCards.Away.ToString() + " db");



            AnsiConsole.Write(kozos);
            AnsiConsole.Write(table);
            Console.WriteLine("\n\n");

        }

    }
}
