using Marketing.Helpers;
using Marketing.Models;
using Marketing.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Energy.Marketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GİPAOFController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetGIPAOF(DateTime startDate, DateTime endDate, Period period)
        {
            try
            {
                var url = Constants.GIPAOFUrl;
                var result = await HttpClientHelper.GetFromUrlAsync<IntradayAofAverangeResponse>(url, startDate, endDate, period);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
