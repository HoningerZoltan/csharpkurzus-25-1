using Sporteredmenyek.Core.Models;
using Sporteredmenyek.Dto;
using Sporteredmenyek.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sporteredmenyek.Services
{
    public class MatchService
    {
        private List<Match> _matches = new();
        private string _basePath;

        public MatchService(string path) 
        {
            this._basePath = path;
            LoadFootballMatches();
            LoadBasketballMatches();
            LoadHockeyMatches();
        }
        public List<FootballMatch> getFootballMatches() 
        {
            List<FootballMatch> matches = new();
            for (int i = 0; i < _matches.Count; i++)
            {
                if (_matches[i] is FootballMatch footballMatch) 
                {
                    matches.Add(footballMatch);
                }
            }
            return matches;
        }
        public List<BasketballMatch> GetBasketballMatches()
        {
            List<BasketballMatch> matches = new();
            for (int i = 0; i < _matches.Count; i++)
            {
                if (_matches[i] is BasketballMatch basketballMatch)
                {
                    matches.Add(basketballMatch);
                }
            }
            return matches;
        }

        public List<HockeyMatch> GetHockeyMatches()
        {
            List<HockeyMatch> matches = new();
            for (int i = 0; i < _matches.Count; i++)
            {
                if (_matches[i] is HockeyMatch hockeyMatch)
                {
                    matches.Add(hockeyMatch);
                }
            }
            return matches;
        }
        public List<Match> GetAllMatches() 
        {
            return _matches;
        }
        public void AddMatch(Match match) 
        {
            _matches.Add(match);
            SaveFootballMatches();
            SaveBasketballMatches();
            SaveHockeyMatches();
        }
        public void SaveFootballMatches()
        {
            List<FootballMatch> matches = getFootballMatches();
            string fileName = "footballMatches.json";
            string fullPath = Path.Combine(_basePath, fileName);

            try
            {
                var dtos = matches.Select(match => match.ToDto()).ToList();
                var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fullPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a mérkőzés mentésekor: " + ex.Message);
            }


        }

        public void SaveBasketballMatches()
        {
            List<BasketballMatch> matches = GetBasketballMatches();
            string fileName = "basketballMatches.json";
            string fullPath = Path.Combine(_basePath, fileName);

            try
            {
                var dtos = matches.Select(match => match.ToDto()).ToList();
                var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fullPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a mérkőzés mentésekor: " + ex.Message);
            }


        }
        public void SaveHockeyMatches()
        {
            List<HockeyMatch> matches = GetHockeyMatches();
            string fileName = "hockeyMatches.json";
            string fullPath = Path.Combine(_basePath, fileName);

            try
            {
                var dtos = matches.Select(match => match.ToDto()).ToList();
                var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fullPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a mérkőzés mentésekor: " + ex.Message);
            }


        }
        public void LoadFootballMatches()
        {
            string fileName= "footballMatches.json";
            string fullPath = Path.Combine(_basePath, fileName);
            try
            {
                if (File.Exists(fullPath))
                {
                    var json = File.ReadAllText(fullPath);
                    var dtos = JsonSerializer.Deserialize<List<JsonFootballDto>>(json);
                    if (dtos != null)
                    {
                        _matches.AddRange(dtos.Select(dto => dto.ToDomainObject()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a Focimeccsek betöltésekor: " + ex.Message);
            }
        }
        public void LoadBasketballMatches()
        {
            string fileName = "basketballMatches.json";
            string fullPath = Path.Combine(_basePath, fileName);
            try
            {
                if (File.Exists(fullPath))
                {
                    var json = File.ReadAllText(fullPath);
                    var dtos = JsonSerializer.Deserialize<List<JsonBasketballDto>>(json);
                    if (dtos != null)
                    {
                        _matches.AddRange(dtos.Select(dto => dto.ToDomainObject()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a Kosárlabda betöltésekor: " + ex.Message);
            }
        }
        public void LoadHockeyMatches()
        {
            string fileName = "hockeyMatches.json";
            string fullPath = Path.Combine(_basePath, fileName);
            try
            {
                if (File.Exists(fullPath))
                {
                    var json = File.ReadAllText(fullPath);
                    var dtos = JsonSerializer.Deserialize<List<JsonHockeyDto>>(json);
                    if (dtos != null)
                    {
                        _matches.AddRange(dtos.Select(dto => dto.ToDomainObject()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a Jégkorong betöltésekor: " + ex.Message);
            }
        }

    }
}
