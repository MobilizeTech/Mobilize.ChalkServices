using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Mobilize.ChalkServices.MobileAppService.Helpers;
using Mobilize.ChalkServices.MobileAppService.Models.SportsRadar;

namespace Mobilize.ChalkServices.Controllers
{
    [Route("api/[controller]")]
    public class MatchupNflController : Controller
    {
        [HttpGet("{Week}")]
        public async Task<IActionResult> GetSchedule(int week)
        {
            int year = DateTime.Now.Year;
            string season = Constants.KeyRegularSeason;
            var schedule = await MatchupHelper.GetNflMatchups(year, season, week);
            return Ok(schedule.Values);
        }

        [HttpGet("{GameId}")]
        public async Task<IActionResult> GetScore(string gameId)
        {
            var score = await MatchupHelper.GetNflScore(gameId);
            return Ok(score);
        }
    }
}