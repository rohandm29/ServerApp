using System.Threading.Tasks;
using System.Web.Http;
using Kalingo.Games.Contract.Entity.Captcha;
using Kalingo.Games.Contract.Entity.Voucher;
using Kalingo.WebApi.Processors;

namespace Kalingo.WebApi.Controllers
{
    //[Authorize]
    [RoutePrefix("country")]
    public class CountryController : ApiController
    {
        private readonly VoucherProcessor _processor;

        public CountryController(VoucherProcessor processor)
        {
            _processor = processor;
        }
        
        [Route("Get")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCountries()
        {
            var image = await _processor.GetVouchers(countryId);

            return Ok(image);
        }
    }
}
