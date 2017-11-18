using System.Collections.Generic;

namespace Kalingo.Games.Contract.Entity.Voucher
{
    public class VoucherClaimResponse
    {
        public VoucherCodes Code { get; set; }
        
        public List<string> Error { get; }

        public VoucherClaimResponse(VoucherCodes errorCode, List<string> error = null)
        {
            Code = errorCode;
            Error = error;
        }
    }
}
