﻿using Spectre.Console;
using Sporteredmenyek.Core.Models;
using Sporteredmenyek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sporteredmenyek.UI
{
    class UiPrinter
    {
        readonly UserService userService = new UserService("Data/users.json");
        readonly MatchService matchService = new MatchService("Data/");
        public void ClearConsole() 
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("SPORT").Centered().Color(Color.Green));
            AnsiConsole.Write(new FigletText("EREDMENYEK").Centered().Color(Color.Red3));
        }

        public void MainLoop()
        {
            while (true)
            {
                ClearConsole();
                Console.WriteLine("Mit szeretne tenni?\n1 - Bejelentkezés\n2 - Regisztráció\nx - Kilépés");
                string input = Console.ReadLine();

                if (input == "x")
                    break;
                else if (input == "1")
                {
                    User result = SignIn();
                    if (result is not null) { SignedInMenu(result); }
                    else
                    {
                        AnsiConsole.MarkupLine("[bold red]Hiba a bejelentkezés során[/]");
                        Console.ReadKey();
                    }
                }
                else if (input == "2")
                {
                    int result = Register();
                    if (result == 1)
                    {
                        Console.WriteLine("Sikeres regisztráció!");
                        Console.ReadKey();
                    }
                    else if (result == -1)
                    {
                        AnsiConsole.MarkupLine("[bold yellow]Regisztráció megszakítva[/]");
                        Console.ReadKey();
                    }
                    else 
                    {
                        AnsiConsole.MarkupLine("[bold red]Hiba a regisztráció során[/]");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Érvénytelen választás. Nyomj egy gombot a folytatáshoz.");
                    Console.ReadKey();
                }
            }
        }

        /*public int MainMenu() 
        {
            Console.WriteLine("Mit szeretne tenni? \n 1 - Bejelentkezés \n 2 - Regisztráció");
            try
            {
                int menuValue = int.Parse(Console.ReadLine());
                if (menuValue != 1 && menuValue != 2)
                    throw new Exception();
                return menuValue;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }*/

        public void Error(string message) {AnsiConsole.MarkupLine("[bold red]HIBA:[/] " + message);Console.ReadKey(); }

        public int Register() 
        {
            ClearConsole();
            AnsiConsole.MarkupLine("[bold underline]Regisztráció[/]");
            Console.WriteLine("(Kilépéshez irja be az x karaktert)\n");
            Console.Write("Adja meg a nevét: ");
            string name = Console.ReadLine();
            if (name == "x") { return -1; }     
            Console.Write("Adja meg az email címét: ");
            string email = Console.ReadLine();
            if (email == "x") { return -1; }
            
            Console.Write("Adjon meg egy jelszót: ");
            string password = Console.ReadLine();
            if (password == "x") { return -1; }
            //Foglalt e az emailcím
            if (userService.EmailExists(email.Trim())){
                Error("Ez az emailcím már foglalt!");
                return 0;
            }
            try
            {
                var addr = new MailAddress(email.Trim());
            }
            catch (Exception ex)
            {
                Error("Hibás email formátum!");
                return 0;
            }

            User newUser = new User(name,email,password);
            try
            {
                userService.AddUser(newUser);
                return 1;

            }
            catch (Exception ex) { Error(ex.Message);return 0; }
            
        }

        public User SignIn()
        {
            ClearConsole();
            User returnValue=null;
            AnsiConsole.MarkupLine("[bold underline]Bejelentkezés[/]");
            Console.WriteLine("(Kilépéshez irja be az x karaktert)\n");
            Console.Write("Email-cím: ");
            string email = Console.ReadLine();
            if (email == "x") { return null; }
            Console.Write("Jelszó: ");
            string password = Console.ReadLine();
            if (password == "x") { return null; }
            var users = userService.getUsers();
            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public void SignedInMenu(User user)
        {
            if (user.Email == "admin@admin.hu")
            {
                ClearConsole();
                bool stayInMenu = true;
                while (stayInMenu)
                {
                    ClearConsole();
                    AnsiConsole.MarkupLine("[bold underline]Milyen mérkőzést rögzít?[/]");
                    Console.WriteLine("1 - Labdarúgás");
                    Console.WriteLine("2 - Jégkorong");
                    Console.WriteLine("3 - Kosárlabda");
                    Console.WriteLine("x - Kijelentkezés");
                    

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            ClearConsole();
                            AnsiConsole.MarkupLine("[bold underline]Labdarúgás mérkőzés:[/]");
                            try
                            {
                                Console.Write("Mérkőzés időpontja(pl. \'2025.01.01. 09:10\'): ");
                                DateTime.TryParse(Console.ReadLine(), out DateTime time);
                                Console.Write("Mérkőzés helyszíne: ");
                                string location = Console.ReadLine();
                                Console.Write("Hazai csapat neve: ");
                                string homeTeam = Console.ReadLine();
                                Console.Write("Vendég csapat neve: ");
                                string awayTeam = Console.ReadLine();
                                Console.Write("Hazai csapat elért pontszáma: ");
                                int homeResult = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég csapat elért pontszáma: ");
                                int awayResult = int.Parse(Console.ReadLine());
                                Console.Write("(Hazai csapat szögletek: ");
                                int homeCorners = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég csapat szögletek: ");
                                int awayCorners = int.Parse(Console.ReadLine());
                                Console.Write("(Hazai csapat sárgalapok: ");
                                int homeYellowCards = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég csapat sárgalapok: ");
                                int awayYellowCards = int.Parse(Console.ReadLine());
                                Console.Write("(Hazai csapat piroslapok: ");
                                int homeRedCards = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég csapat piroslapok: ");
                                int awayRedCards = int.Parse(Console.ReadLine());
                                FootballMatch match = new FootballMatch(
                                    homeTeam,
                                    awayTeam,
                                    time,
                                    location,
                                    new TeamsIntValuePair(homeResult, awayResult),
                                    new TeamsIntValuePair(homeRedCards, awayRedCards),
                                    new TeamsIntValuePair(homeYellowCards, awayYellowCards),
                                    new TeamsIntValuePair(homeCorners, awayCorners)
                                    );
                                matchService.AddMatch(match);

                            }
                            catch (Exception ex) { Error(ex.Message); }
                            break;
                        case "2":
                            ClearConsole();
                            AnsiConsole.MarkupLine("[bold underline]Jégkorong mérkőzés:[/]");
                            try
                            {
                                Console.Write("Mérkőzés időpontja(pl. \'2025.01.01. 09:10\'): ");
                                DateTime.TryParse(Console.ReadLine(), out DateTime time);
                                Console.Write("Mérkőzés helyszíne: ");
                                string location = Console.ReadLine();
                                Console.Write("Hazai csapat neve: ");
                                string homeTeam = Console.ReadLine();
                                Console.Write("Vendég csapat neve: ");
                                string awayTeam = Console.ReadLine();
                                Console.Write("Hazai csapat elért pontszáma: ");
                                int homeResult = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég csapat elért pontszáma: ");
                                int awayResult = int.Parse(Console.ReadLine());
                                Console.Write("(Hazai csapat büntetőpercek: ");
                                int homePenalty = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég csapat büntetőpercek: ");
                                int awayPenalty = int.Parse(Console.ReadLine());
                                Console.Write("(Hazai csapat kaput eltalált lövései: ");
                                int homeShots = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég kaput eltalált lövései: ");
                                int awayShots = int.Parse(Console.ReadLine());

                                HockeyMatch match = new HockeyMatch(
                                    homeTeam,
                                    awayTeam,
                                    time,
                                    location,
                                    new TeamsIntValuePair(homeResult, awayResult),
                                    new TeamsIntValuePair(homePenalty, awayPenalty),
                                    new TeamsIntValuePair(homeShots, awayShots)
                                );
                                matchService.AddMatch(match);

                            }
                            catch (Exception ex) { Error(ex.Message); }
                            break;
                        case "3":
                            ClearConsole();
                            AnsiConsole.MarkupLine("[bold underline]Jégkorong mérkőzés:[/]");
                            try
                            {
                                Console.Write("Mérkőzés időpontja(pl. \'2025.01.01. 09:10\'): ");
                                DateTime.TryParse(Console.ReadLine(), out DateTime time);
                                Console.Write("Mérkőzés helyszíne: ");
                                string location = Console.ReadLine();
                                Console.Write("Hazai csapat neve: ");
                                string homeTeam = Console.ReadLine();
                                Console.Write("Vendég csapat neve: ");
                                string awayTeam = Console.ReadLine();
                                Console.Write("Hazai csapat elért pontszáma: ");
                                int homeResult = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég csapat elért pontszáma: ");
                                int awayResult = int.Parse(Console.ReadLine());
                                Console.Write("(Hazai csapat szabálytalanságok: ");
                                int homePenalty = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég csapat szabálytalanságok: ");
                                int awayPenalty = int.Parse(Console.ReadLine());
                                Console.Write("(Hazai csapat hárompontosai: ");
                                int homeThreePoints = int.Parse(Console.ReadLine());
                                Console.Write("(Vendég csapat hárompontosai: ");
                                int awayThreePoints = int.Parse(Console.ReadLine());

                                BasketballMatch match = new BasketballMatch(
                                    homeTeam,
                                    awayTeam,
                                    time,
                                    location,
                                    new TeamsIntValuePair(homeResult, awayResult),
                                    new TeamsIntValuePair(homePenalty, awayPenalty),
                                    new TeamsIntValuePair(homeThreePoints, awayThreePoints)
                                );
                                matchService.AddMatch(match);

                            }
                            catch (Exception ex) { Error(ex.Message); }
                            break;
                        case "x":
                            stayInMenu = false;
                            break;
                        default:
                            Error("Nincs ilyen menüelem!");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            else
            {
                ClearConsole();
                bool stayInMenu = true;
                while (stayInMenu)
                {
                    ClearConsole();
                    AnsiConsole.MarkupLine("[bold underline]Milyen eredmények érdekelnek?[/]");
                    Console.WriteLine("1 - Minden sportág");
                    Console.WriteLine("2 - Jégkorong");
                    Console.WriteLine("3 - Kosárlabda");
                    Console.WriteLine("4 - Labdarúgás");
                    Console.WriteLine("x - Kijelentkezés");

                    string choice = Console.ReadLine();
                    

                    switch (choice)
                    {

                        case "1":
                            var orderedMatches = matchService.GetAllMatches()
                                .OrderByDescending(m => m.StartTime)
                                .ToList();
                            foreach (var match in orderedMatches)
                                match.Print();       
                            Console.ReadKey();
                            break;
                        case "2":
                            var hockeyMatches = matchService.GetAllMatches()
                                .Where(m => m is HockeyMatch)
                                .Cast<HockeyMatch>()
                                .OrderByDescending(m => m.StartTime)
                                .ToList();
                            foreach (var match in hockeyMatches)
                                match.Print();
                            Console.ReadKey();
                            break;
                        case "3":
                            var basketballMatches = matchService.GetAllMatches()
                                .Where(m => m is BasketballMatch)
                                .Cast<BasketballMatch>()
                                .OrderByDescending(m => m.StartTime)
                                .ToList();
                            foreach (var match in basketballMatches)
                                match.Print();
                            Console.ReadKey();
                            break;
                        case "4":
                            var footballMatches = matchService.GetAllMatches()
                                .Where(m => m is FootballMatch)
                                .Cast<FootballMatch>()
                                .OrderByDescending(m => m.StartTime)
                                .ToList();
                            foreach (var match in footballMatches)
                                match.Print();
                            Console.ReadKey();
                            break;
                        case "x":
                            stayInMenu = false;
                            break;
                        default:
                            Error("Nincs ilyen menüelem!");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
    }
}
