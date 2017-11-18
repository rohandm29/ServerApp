using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Voucher;
using Kalingo.WebApi.Domain.Data.Repository;

namespace Kalingo.WebApi.Processors
{
    public class VoucherProcessor
    {
        private readonly VoucherRepository _voucherRepository;

        public VoucherProcessor(VoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        public async Task<IEnumerable<VoucherResponse>> GetVouchers(int countryId)
        {
            try
            {
                return await _voucherRepository.GetVouchers(countryId);
            }
            catch (Exception)
            {
                return new List<VoucherResponse>();
            }
        }

        public async Task<VoucherClaimResponse> ClaimVoucher(VoucherClaimRequest claim)
        {
            try
            {
                var response = await _voucherRepository.VoucherClaimed(claim);

                return response == 0
                    ? new VoucherClaimResponse(VoucherCodes.NotEnoughCoins)
                    : new VoucherClaimResponse(VoucherCodes.Valid);
            }
            catch (Exception)
            {
                return new VoucherClaimResponse(VoucherCodes.NoVouchers);
            }
        }
    }
}