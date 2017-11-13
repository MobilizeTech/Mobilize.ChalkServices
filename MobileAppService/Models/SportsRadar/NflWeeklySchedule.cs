
namespace Mobilize.ChalkServices.MobileAppService.Models.SportsRadar
{
    public class NflWeeklySchedule
    {
        public string id { get; set; }
        public int year { get; set; }
        public NflWeeklyScheduleWeek week { get; set; }
    }
}