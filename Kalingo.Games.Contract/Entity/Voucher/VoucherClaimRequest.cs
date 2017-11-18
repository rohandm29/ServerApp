namespace Kalingo.Games.Contract.Entity.Voucher
{
    public class VoucherClaimRequest
    {
        public int VoucherId { get; }

        public int UserId { get; }

        public VoucherClaimRequest(int voucherId, int userId)
        {
            VoucherId = voucherId;
            UserId = userId;
        }
    }
}
