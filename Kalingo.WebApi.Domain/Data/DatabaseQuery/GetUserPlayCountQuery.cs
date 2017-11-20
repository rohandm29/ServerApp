using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetUserPlayCountQuery
    {
        private readonly string _connectionString;

        public GetUserPlayCountQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Execute(int userId)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspGetUserLimit",
                    new {@userId},
                    commandType: CommandType.StoredProcedure);

                var captcha = await conn.QueryAsync<int>(command);

                return captcha.FirstOrDefault();
            }
        }
    }
}
