using System.Threading.Tasks;
using System.Web.Http;
using Kalingo.Games.Contract.Entity.Voucher;
using Kalingo.WebApi.Processors;

namespace Kalingo.WebApi.Controllers
{
    //[Authorize]
    [RoutePrefix("api/voucher")]
    public class VoucherController : ApiController
    {
        private readonly VoucherProcessor _processor;

        public VoucherController(VoucherProcessor processor)
        {
            _processor = processor;
        }
        
        [Route("Get")]
        [HttpGet]
        public async Task<IHttpActionResult> GetVouchers(int countryId)
        {
            var image = await _processor.GetVouchers(countryId);

            return Ok(image);
        }
        
        [Route("Claim")]
        [HttpPost]
        public async Task<IHttpActionResult> ClaimVoucher(VoucherClaimRequest claim)
        {
            var claimResponse = await _processor.ClaimVoucher(claim);

            return Ok(claimResponse);
        }
    }
}
