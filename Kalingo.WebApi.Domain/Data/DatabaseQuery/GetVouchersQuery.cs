using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity.Voucher;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetVouchersQuery
    {
        private readonly string _connectionString;

        public GetVouchersQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<VoucherResponse>> Execute(int countryId)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspGetVouchers",
                    new {countryId = countryId},
                    commandType: CommandType.StoredProcedure);

                var vouchers = await conn.QueryAsync<VoucherResponse>(command);

                return vouchers;
            }
        }
    }
}
