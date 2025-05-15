using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Sporteredmenyek.Core.Models
{
    public record HockeyMatch : Match
    {
        public override int PeriodsNumber { get; } = 3;

        public TeamsIntValuePair PenaltyMinutes { get; init; }
        public TeamsIntValuePair ShotsOnGoal { get; init; }


        public HockeyMatch(
            string homeTeam, 
            string awayTeam, 
            DateTime start_time, 
            string location,
            TeamsIntValuePair result,
            TeamsIntValuePair penaltyMinutes,
            TeamsIntValuePair shotsOnGoal
        )  : base(homeTeam, awayTeam, start_time, location, result)
        {
            PenaltyMinutes = penaltyMinutes;
            ShotsOnGoal = shotsOnGoal;
        }
        public override void Print()
        {
            var kozos = new Table();
            kozos.Width(80);
            kozos.Border(TableBorder.None);
            kozos.AddColumn(new TableColumn(new Markup("[bold]----------------------------- Jégkorong -----------------------------[/]")).Centered()).Centered();

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
            table.AddRow("Kaput eltalált lövések:", ShotsOnGoal.Home.ToString(), ShotsOnGoal.Away.ToString());
            table.AddRow("Büntetőpercek:", PenaltyMinutes.Home.ToString()+" perc", PenaltyMinutes.Away.ToString() + " perc");



            AnsiConsole.Write(kozos);
            AnsiConsole.Write(table);
            Console.WriteLine("\n\n");

        }


    }
}
