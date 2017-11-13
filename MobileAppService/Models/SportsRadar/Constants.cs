using Mobilize.ChalkServices.MobileAppService.Utility;

namespace Mobilize.ChalkServices.MobileAppService.Models.SportsRadar
{
    public static class Constants
    {
        public static readonly string ApiKey = Settings.SportsRadarApiKey;
        public static readonly string BaseUrl = "http://api.sportradar.us/";

        public static readonly string KeyRegularSeason = "REG";
        public static readonly string KeyOutdoor = "outdoor";
        public static readonly string KeyInProgress = "inprogress";
        public static readonly string KeyClosed = "closed";

        public static readonly string ResourceNflSchedule = "nfl-ot2/games/{year}/{season}/{week}/schedule.json";
        public static readonly string ResourceNflBoxscore = "nfl-ot2/games/{game_id}/boxscore.json";
    }
}
