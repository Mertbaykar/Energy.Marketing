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
        public ActionResult GetMarginalPrices(DateTime startDate, DateTime endDate, string? region)
        {
            try
            {
                List<SMPResponse> result = new();

                for (int i = 0; i < 3; i++)
                {
                    var smpResponse = SMPResponseGenerator.Generate();
                    result.Add(smpResponse);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
          
        }
    }
}
