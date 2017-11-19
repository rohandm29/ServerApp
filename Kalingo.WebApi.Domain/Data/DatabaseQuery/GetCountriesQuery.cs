using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetCountriesQuery
    {
        private readonly string _connectionString;

        public GetCountriesQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<CountryResponse>> Execute()
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspGetCountries",
                    commandType: CommandType.StoredProcedure);

                var vouchers = await conn.QueryAsync<CountryResponse>(command);

                return vouchers;
            }
        }
    }
}
