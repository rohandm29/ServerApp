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
        private readonly CountryProcessor _processor;

        public CountryController(CountryProcessor processor)
        {
            _processor = processor;
        }
        
        [Route("Get")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCountries()
        {
            var image = await _processor.GetCountries();

            return Ok(image);
        }
    }
}
