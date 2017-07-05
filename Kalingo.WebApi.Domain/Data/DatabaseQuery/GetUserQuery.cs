using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetUserQuery
    {
        private readonly string _connectionString;

        public GetUserQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Execute(string userName)
        {
            try
            {   
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspGetUserId",
                        new {@userName = userName},
                        commandType: CommandType.StoredProcedure);

                    var validUser = await conn.ExecuteScalarAsync<int>(command);

                    return validUser;
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
