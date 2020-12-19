using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Entity.Values;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IValuesService _valuesService;
        public TestController(IValuesService valuesService)
        {
            _valuesService = valuesService;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllValues()
        {
            return Ok(await _valuesService.GetAllValues());
        }

        [HttpGet("GetSingle/{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _valuesService.GetSingle(id));
        }

        [HttpPost("EnterValue")]
        public async Task<IActionResult> EnterValue(EnterValuesRequest req)
        {
            return Ok(await _valuesService.EnterValue(req));
        }

        [HttpPut("UpdateValue")]
        public async Task<IActionResult> UpdateValue(UpdateValuesRequest req)
        {
            return Ok(await _valuesService.UpdateValue(req));
        }

        [HttpDelete("DeleteValue")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            ServiceResponse<List<GetValuesResponse>> response = await _valuesService.DeleteValue(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}