using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class CreateMinesBoomCommand
    {
        private readonly string _connectionString;

        public CreateMinesBoomCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Execute(int userId, string randomSequence)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspCreateMinesBoom", 
                        new {userId, randomSequence}, 
                        commandType: CommandType.StoredProcedure);

                    var gameId = await conn.ExecuteScalarAsync<int>(command);

                    return gameId;
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
