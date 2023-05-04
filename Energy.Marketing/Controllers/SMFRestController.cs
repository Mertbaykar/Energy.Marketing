using Marketing.Helpers;
using Marketing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Energy.Marketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMFRestController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetMarginalPrices(DateTime startDate, DateTime endDate, string? region)
        {
            try
            {
                var url = Constants.RootUrl + "/transparency/service/market/smp";
                string finalUrl = HttpClientHelper.CreateUrl(url, startDate, endDate);
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(finalUrl);
                var sMPResponse = await result.Content.ReadFromJsonAsync<SMPResponse>();
                return Ok(sMPResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
          
        }
    }
}
