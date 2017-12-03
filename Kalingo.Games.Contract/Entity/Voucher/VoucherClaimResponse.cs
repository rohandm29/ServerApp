using System.Collections.Generic;

namespace Kalingo.Games.Contract.Entity.Voucher
{
    public class VoucherClaimResponse
    {
        public VoucherCodes Code { get; set; }

        public List<string> Error { get; set; }

        public VoucherClaimResponse(VoucherCodes errorCode)
        {
            Code = errorCode;
            Error = new List<string>();
        }
    }
}
