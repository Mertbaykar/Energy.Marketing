using Energy.Marketing.Bases;
using Marketing.Models;
using Marketing.Shared.HttpClients;
using Microsoft.AspNetCore.Mvc;

namespace Energy.Marketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMFRestController : ApiControllerBase
    {
        private readonly SmpClient _smpClient;
        private readonly PtfSmpClient _ptfSmpClient;
        public SMFRestController(SmpClient smpClient, PtfSmpClient ptfSmpClient)
        {
            _smpClient = smpClient;
            _ptfSmpClient = ptfSmpClient;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetMarginalPrices(DateTime startDate, DateTime endDate, string? region)
        {
            try
            {
                //var result = await _smpClient.GetAsync<SMPResponse>(Request.QueryString.Value!);
                var result = await _smpClient.GetAsync<SMPResponse>(startDate, endDate, region: region);

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
                //var result = await _ptfSmpClient.GetAsync<McpSmpResponse>(Request.QueryString.Value!);
                var result = await _ptfSmpClient.GetAsync<McpSmpResponse>(startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
