using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            return await _voucherRepository.GetVouchers(countryId);
        }

        public async Task<VoucherClaimResponse> ClaimVoucher(VoucherClaimRequest claim)
        {
            return await _voucherRepository.VoucherClaimed(claim);
        }
    }
}