﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity.Voucher;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;

namespace Kalingo.WebApi.Domain.Data.Repository
{
    public class VoucherRepository
    {
        private readonly GetVouchersQuery _getVouchersQuery;
        private readonly VoucherClaimedCommand _voucherClaimedCommand;

        public VoucherRepository(GetVouchersQuery getVouchersQuery, VoucherClaimedCommand voucherClaimedCommand)
        {
            _getVouchersQuery = getVouchersQuery;
            _voucherClaimedCommand = voucherClaimedCommand;
        }

        public async Task<IEnumerable<Voucher>> GetVouchers(int countryId)
        {
            return await _getVouchersQuery.Execute(countryId);
        }

        public async Task<VoucherClaimResponse> VoucherClaimed(VoucherClaim claim)
        {
            return await _voucherClaimedCommand.Execute(claim);
;        }
    }
}