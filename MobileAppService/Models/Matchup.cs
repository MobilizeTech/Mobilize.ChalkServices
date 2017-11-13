using System;

namespace Mobilize.ChalkServices.MobileAppService.Models
{
    public class Matchup
    {
        public string Id { get; set; }
        public DateTime Scheduled { get; set; }
        public string Status { get; set; }
        public string VenueName { get; set; }
        public string VenueLocation { get; set; }
        public bool VenueOutdoor { get; set; }
        public string WeatherSynopsis { get; set; }
        public string BroadcastNetwork { get; set; }

        public string HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }

        public string AwayTeamId { get; set; }
        public string AwayTeamName { get; set; }
    }
}