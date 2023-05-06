using Energy.Marketing.Bases;
using Marketing.Helpers;
using Marketing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Energy.Marketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMFRestController : ApiControllerBase
    {
        [HttpGet("[action]")]
        public async Task<ActionResult> GetMarginalPrices(DateTime startDate, DateTime endDate, string? region)
        {
            try
            {
                var url = Constants.MarginalPriceUrl + Request.QueryString.Value;
                var result = await HttpClientHelper.GetFromUrlAsync<SMPResponse>(url);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
          
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetPTFAndSMF(DateTime startDate, DateTime endDate)
        {
            try
            {
                var url = Constants.PTFAndSMFUrl + Request.QueryString.Value;
                var result = await HttpClientHelper.GetFromUrlAsync<McpSmpResponse>(url);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
