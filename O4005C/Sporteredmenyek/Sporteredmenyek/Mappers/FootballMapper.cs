using Sporteredmenyek.Core.Models;
using Sporteredmenyek.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Mappers
{
    public static class FootballMapper
    {
        public static JsonFootballDto ToDto(this FootballMatch match) {

            List<int> periodResultsHome = new List<int>();
            List<int> periodResultsAway = new List<int>();
            return new JsonFootballDto
            {
                HomeTeam = match.HomeTeam,
                AwayTeam = match.AwayTeam,
                StartTime = match.StartTime,
                Location = match.Location,
                ResultHome = match.Result.Home,
                ResultAway = match.Result.Away,
                YellowCardsHome = match.YellowCards.Home,
                YellowCardAway = match.YellowCards.Away,
                RedCardsHome = match.RedCards.Home,
                RedCardAway = match.RedCards.Away,
                CornersHome = match.Corners.Home,
                CornersAway = match.Corners.Away

            };
        }
        public static FootballMatch ToDomainObject(this JsonFootballDto dto) 
        {
            TeamsIntValuePair result = new TeamsIntValuePair();
            result.Home = dto.ResultHome;
            result.Away = dto.ResultAway;
            List<TeamsIntValuePair> periodResults = new List<TeamsIntValuePair>();
            TeamsIntValuePair yellowCards = new TeamsIntValuePair();
            result.Home = dto.YellowCardsHome;
            result.Away = dto.YellowCardAway;
            TeamsIntValuePair redCards = new TeamsIntValuePair();
            result.Home = dto.RedCardsHome;
            result.Away = dto.RedCardAway;
            TeamsIntValuePair corners = new TeamsIntValuePair();
            result.Home = dto.CornersHome;
            result.Away = dto.CornersAway;

            return new FootballMatch
            (
                dto.HomeTeam,
                dto.AwayTeam,
                dto.StartTime,
                dto.Location,
                result,
                redCards,
                yellowCards,
                corners
            );
        }
    }
}
