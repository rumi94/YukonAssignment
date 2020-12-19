using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Entity.Values;
using Logic;
using Logic.TimeTable;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeTableController : ControllerBase
    {
        private readonly ITimeTableService _valuesService;
        public TimeTableController(ITimeTableService valuesService)
        {
            _valuesService = valuesService;

        }

        [HttpGet("GetTimeTable")]
        public async Task<IActionResult> GetTimeTable(string day, string user, int teacherId)
        {
            return Ok(await _valuesService.GetTimeTable(day,user,teacherId));
        }

        [HttpPut("UpdateLeave")]
        public async Task<IActionResult> UpdateLeave(int teacherId, string day)
        {
            return Ok(await _valuesService.UpdateLeave(teacherId,day));
        }

    }
}