using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetConfigQuery
    {
        private readonly string _connectionString;

        public GetConfigQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Config> Execute(int countryId)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspGetMinesboomConfig",
                    new
                    {
                        countryId
                    },
                    commandType: CommandType.StoredProcedure);

                var limit = await conn.QueryAsync<Config>(command);

                return limit.FirstOrDefault();
            }
        }
    }
}
