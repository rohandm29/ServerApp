using System;
using System.Collections.Generic;
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
    public class GetVouchersQuery
    {
        private readonly string _connectionString;

        public GetVouchersQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Voucher>> Execute(int countryId)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspGetVouchers",
                        new { countryId = countryId },
                        commandType: CommandType.StoredProcedure);

                    var vouchers = await conn.QueryAsync<Voucher>(command);

                    return vouchers;
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
