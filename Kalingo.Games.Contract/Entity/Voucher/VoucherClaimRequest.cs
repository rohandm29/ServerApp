namespace Kalingo.Games.Contract.Entity.Voucher
{
    public class VoucherClaimRequest
    {
        public int VoucherId { get; }

        public string UserId { get; }

        public VoucherClaimRequest(int voucherId, string userId)
        {
            VoucherId = voucherId;
            UserId = userId;
        }
    }
}
