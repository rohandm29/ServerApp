﻿using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Services;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class AddUserCommand
    {
        private readonly string _connectionString;

        public AddUserCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Execute(NewUserRequest user)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspAddUser",
                    new
                    {
                        @userName = user.UserName,
                        @password = user.Password,
                        @emailaddress = user.Email,
                        @country = user.CountryId
                    },
                    commandType: CommandType.StoredProcedure);

                var validUser = await conn.ExecuteScalarAsync<int>(command);

                return validUser;
            }
        }
    }
}
