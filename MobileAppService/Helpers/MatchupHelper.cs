using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using Mobilize.ChalkServices.MobileAppService.Models;
using Mobilize.ChalkServices.MobileAppService.Models.SportsRadar;

using Newtonsoft.Json;

namespace Mobilize.ChalkServices.MobileAppService.Helpers
{
    public static class MatchupHelper
    {
        public static async Task<ConcurrentDictionary<string, Matchup>> GetNflMatchups(int year, string season, int week)
        {
            var matchups = new ConcurrentDictionary<string, Matchup>();
            var schedule = await GetNflSchedule(year, season, week);
            return HydrateNflMatchups(matchups, schedule);
        }

        private static async Task<NflWeeklySchedule> GetNflSchedule(int year, string season, int week)
        {
            var parameters = new Dictionary<string, string>
                {
                    { "api_key", Constants.ApiKey }
                };
            var urlSegments = new Dictionary<string, string>
                {
                    { "year", year.ToString() },
                    { "season", season },
                    { "week", week.ToString() }
                };
            var response = await ApiHelper.GetData(Constants.BaseUrl, Constants.ResourceNflSchedule, parameters, urlSegments);
            return JsonConvert.DeserializeObject<NflWeeklySchedule>(response.Content);
        }

        private static ConcurrentDictionary<string, Matchup> HydrateNflMatchups(ConcurrentDictionary<string, Matchup> matchups, NflWeeklySchedule schedule)
        {
            if (schedule != null)
            {
                foreach (NflWeeklyScheduleGame game in schedule.week.games)
                {
                    var matchup = new Matchup
                    {
                        Id = game.id,
                        Scheduled = game.scheduled,
                        Status = game.status,
                        VenueName = game.venue.name,
                        VenueLocation = string.Format("{0}, {1}", game.venue.city, game.venue.state),
                        VenueOutdoor = game.venue.roof_type.Equals(Constants.KeyOutdoor),
                        WeatherSynopsis = string.Empty,
                        BroadcastNetwork = game.broadcast.network,
                        HomeTeamId = game.home.alias,
                        HomeTeamName = game.home.name,
                        AwayTeamId = game.away.alias,
                        AwayTeamName = game.away.name
                    };

                    matchups.TryAdd(matchup.Id, matchup);
                }
            }

            return matchups;
        }

        public static async Task<MatchupFootballScore> GetNflScore(string gameId)
        {
            var score = new MatchupFootballScore();
            var boxscore = await GetMatchupFootballScore(gameId);
            return HydrateNflScore(score, boxscore);
        }

        private static async Task<NflBoxscore> GetMatchupFootballScore(string gameId)
        {
            var parameters = new Dictionary<string, string>
                {
                    { "api_key", Constants.ApiKey }
                };
            var urlSegments = new Dictionary<string, string>
                {
                    { "game_id", gameId }
                };
            var response = await ApiHelper.GetData(Constants.BaseUrl, Constants.ResourceNflBoxscore, parameters, urlSegments);
            return JsonConvert.DeserializeObject<NflBoxscore>(response.Content);
        }

        private static MatchupFootballScore HydrateNflScore(MatchupFootballScore score, NflBoxscore boxscore)
        {
            score.Quarter = boxscore.quarter;
            score.Clock = boxscore.clock;
            score.HomeTeamPoints = boxscore.summary.home.points;
            score.AwayTeamPoints = boxscore.summary.away.points;
            return score;
        }
    }
}