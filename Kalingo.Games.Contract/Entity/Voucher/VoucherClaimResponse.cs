namespace Kalingo.Games.Contract.Entity.Voucher
{
    public class VoucherClaimResponse
    {
        public bool Result { get; }
        public string Comment { get; }

        public VoucherClaimResponse(bool result, string comment)
        {
            Result = result;
            Comment = comment;
        }
    }
}
