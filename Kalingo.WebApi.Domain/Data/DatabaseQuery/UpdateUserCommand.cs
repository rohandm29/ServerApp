using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity;
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

        public async Task Execute(UpdateUser user)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspUpdateUser",
                        new
                        {
                            @userId = user.UserId,
                            @emailaddress = user.Email,
                            @country = CountryService.GetCountry(user.Country)
                        },
                        commandType: CommandType.StoredProcedure);

                    await conn.ExecuteScalarAsync<int>(command);
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
