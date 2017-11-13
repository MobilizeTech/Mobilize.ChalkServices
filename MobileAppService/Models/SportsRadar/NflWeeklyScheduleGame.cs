using System;

namespace Mobilize.ChalkServices.MobileAppService.Models.SportsRadar
{
    public class NflWeeklyScheduleGame
    {
        public string id { get; set; }
        public string status { get; set; }
        public DateTime scheduled { get; set; }
        public NflWeeklyScheduleVenue venue { get; set; }
        public NflTeam home { get; set; }
        public NflTeam away { get; set; }
        public NflWeeklyScheduleBroadcast broadcast { get; set; }
    }
}