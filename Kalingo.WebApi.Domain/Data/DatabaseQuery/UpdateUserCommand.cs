using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Services;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class UpdateUserCommand
    {
        private readonly string _connectionString;

        public UpdateUserCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Execute(UpdateUserRequest user)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspUpdateUser",
                    new
                    {
                        @userId = user.UserId,
                        @emailaddress = user.Email,
                        @country = user.CountryId
                    },
                    commandType: CommandType.StoredProcedure);

                await conn.ExecuteScalarAsync<int>(command);
            }
        }
    }
}
