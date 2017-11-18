using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetUserLimitQuery
    {
        private readonly string _connectionString;

        public GetUserLimitQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Execute(int userId)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspGetUserLimit",
                    new {@userId = userId},
                    commandType: CommandType.StoredProcedure);

                var limit = await conn.QueryAsync<int>(command);

                return limit.FirstOrDefault();
            }
        }
    }
}
