using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetUserQuery
    {
        private readonly string _connectionString;

        public GetUserQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UserEntity> Execute(UserArgs user)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspGetUser",
                    new {@userName = user.UserName},
                    commandType: CommandType.StoredProcedure);

                var validUser = await conn.QueryAsync<UserEntity>(command);

                return validUser.FirstOrDefault();
            }
        }
    }
}
