
namespace Mobilize.ChalkServices.MobileAppService.Models.SportsRadar
{
    public class NflWeeklyScheduleWeek
    {
        public string id { get; set; }
        public int sequence { get; set; }
        public NflWeeklyScheduleGame[] games { get; set; }
    }
}