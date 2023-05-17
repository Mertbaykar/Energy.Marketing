using Energy.Marketing.Bases;
using Marketing.Models;
using Marketing.Shared.Enums;
using Marketing.Shared.HttpClients;
using Microsoft.AspNetCore.Mvc;

namespace Energy.Marketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GİPAOFController : ApiControllerBase
    {
        private readonly GipAofClient _gipAofClient;

        public GİPAOFController(GipAofClient gipAofClient)
        {
            _gipAofClient = gipAofClient;
        }

        [HttpGet]
        public async Task<ActionResult> GetGIPAOF(DateTime startDate, DateTime endDate, Period period)
        {
            try
            {
                //var result = await _gipAofClient.GetAsync<IntradayAofAverangeResponse>(Request.QueryString.Value!);
                var result = await _gipAofClient.GetAsync<IntradayAofAverangeResponse>(startDate, endDate, period);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
