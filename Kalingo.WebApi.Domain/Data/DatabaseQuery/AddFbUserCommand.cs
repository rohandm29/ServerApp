using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class AddFbUserCommand
    {
        private readonly string _connectionString;

        public AddFbUserCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UserEntity> Execute(FbUser user)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspAddFbUser",
                    new
                    {
                        @userName = user.UserName,
                        @emailAddress = user.EmailAddress,
                        @countryId = user.CountryId,
                        @deviceId = user.DeviceId,
                        @version = user.Version
                    },
                    commandType: CommandType.StoredProcedure);

                var validUser = await conn.QueryAsync<UserEntity>(command);

                return validUser.FirstOrDefault();
            }
        }
    }
}