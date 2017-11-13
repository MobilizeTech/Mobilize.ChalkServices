using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Mobilize.ChalkServices.MobileAppService.Models.SportsRadar;

using Newtonsoft.Json;

namespace Mobilize.ChalkServices.MobileAppService.Helpers
{
    public static class StandingsHelper
    {
        public static async Task<NflStandings> GetNflStandings(int year)
        {
            var standings = await GetStandings(year);
            return standings;
        }

        private static async Task<NflStandings> GetStandings(int year)
        {
            var parameters = new Dictionary<string, string>
                {
                    { "api_key", Constants.ApiKey }
                };
            var urlSegments = new Dictionary<string, string>
                {
                    { "year", year.ToString() }
                };
            var response = await ApiHelper.GetData(Constants.BaseUrl, Constants.ResourceNflStandings, parameters, urlSegments);
            return JsonConvert.DeserializeObject<NflStandings>(response.Content);
        }
    }
}