using Sporteredmenyek.Core.Models;
using Sporteredmenyek.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Mappers
{
    public static class BasketballMapper
    {
        public static JsonBasketballDto ToDto(this BasketballMatch match)
        {

            List<int> periodResultsHome = new List<int>();
            List<int> periodResultsAway = new List<int>();
            return new JsonBasketballDto
            {
                HomeTeam = match.HomeTeam,
                AwayTeam = match.AwayTeam,
                StartTime = match.StartTime,
                Location = match.Location,
                ResultHome = match.Result.Home,
                ResultAway = match.Result.Away,
                FoulsHome = match.Fouls.Home,
                FoulsAway = match.Fouls.Away,
                ThreePointMadeHome = match.ThreePointMade.Home,
                ThreePointMadeAway = match.ThreePointMade.Away

            };
        }
        public static BasketballMatch ToDomainObject(this JsonBasketballDto dto)
        {
            TeamsIntValuePair result = new TeamsIntValuePair();
            result.Home = dto.ResultHome;
            result.Away = dto.ResultAway;
            List<TeamsIntValuePair> periodResults = new List<TeamsIntValuePair>();
            TeamsIntValuePair fouls = new TeamsIntValuePair();
            result.Home = dto.FoulsHome;
            result.Away = dto.FoulsAway;
            TeamsIntValuePair threePoint = new TeamsIntValuePair();
            result.Home = dto.ThreePointMadeHome;
            result.Away = dto.ThreePointMadeAway;


            return new BasketballMatch
            (
                dto.HomeTeam,
                dto.AwayTeam,
                dto.StartTime,
                dto.Location,
                 result,
                fouls,
                threePoint
            );
        }

    }
}
