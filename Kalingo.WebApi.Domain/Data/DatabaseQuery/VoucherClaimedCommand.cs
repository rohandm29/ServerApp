using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Voucher;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class VoucherClaimedCommand
    {
        private readonly string _connectionString;

        public VoucherClaimedCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<VoucherClaimResponse> Execute(VoucherClaimRequest voucherClaim)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspVoucherClaimed",
                        new
                        {
                            @voucherId = voucherClaim.VoucherId, 
                            @userId = voucherClaim.UserId
                        },
                        commandType: CommandType.StoredProcedure);

                    var claimResponse = await conn.QueryAsync<VoucherClaimResponse>(command);

                    return claimResponse.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
