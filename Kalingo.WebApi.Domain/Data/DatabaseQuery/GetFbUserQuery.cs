using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetFbUserQuery
    {
        private readonly string _connectionString;

        public GetFbUserQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UserEntity> Execute(string userName)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspGetFbUser",
                    new {@userName = userName},
                    commandType: CommandType.StoredProcedure);

                var validUser = await conn.QueryAsync<UserEntity>(command);

                return validUser.FirstOrDefault();
            }
        }
    }
}
