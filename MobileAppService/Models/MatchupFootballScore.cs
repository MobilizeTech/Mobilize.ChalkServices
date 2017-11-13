
namespace Mobilize.ChalkServices.MobileAppService.Models
{
    public class MatchupFootballScore
    {
        public int Quarter { get; set; }
        public string Clock { get; set; }
        public int HomeTeamPoints { get; set; }
        public int AwayTeamPoints { get; set; }
    }
}