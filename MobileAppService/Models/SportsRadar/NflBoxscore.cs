
namespace Mobilize.ChalkServices.MobileAppService.Models.SportsRadar
{
    public class NflBoxscore
    {
        public string id { get; set; }
        public string weather { get; set; }
        public string clock { get; set; }
        public int quarter { get; set; }
        public NflBoxscoreSummary summary { get; set; }
    }
}