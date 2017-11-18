using System.Collections.Generic;

namespace Kalingo.Games.Contract.Entity.Voucher
{
    public class VoucherClaimResponse
    {
        public VoucherErrorCodes ErrorCode { get; set; }
        
        public List<string> Error { get; }

        public VoucherClaimResponse(VoucherErrorCodes errorCode, List<string> error)
        {
            ErrorCode = errorCode;
            Error = error;
        }
    }
}
