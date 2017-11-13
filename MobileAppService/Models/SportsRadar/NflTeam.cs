
namespace Mobilize.ChalkServices.MobileAppService.Models.SportsRadar
{
    public class NflTeam
    {
        public string id { get; set; }
        public string reference { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public int points { get; set; }
        public int remaining_timeouts { get; set; }
        public int used_timeouts { get; set; }
    }
}