namespace Kalingo.Games.Contract.Entity.Voucher
{
    public class VoucherClaim
    {
        public int VoucherId { get; }
        public int UserId { get; }

        public VoucherClaim(int voucherId, int userId)
        {
            VoucherId = voucherId;
            UserId = userId;
        }
    }
}
