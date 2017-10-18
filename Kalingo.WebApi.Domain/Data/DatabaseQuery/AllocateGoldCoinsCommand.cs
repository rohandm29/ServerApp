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
    public class AllocateGoldCoinsCommand
    {
        private readonly string _connectionString;

        public AllocateGoldCoinsCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Execute(int userId, int gameId)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspAllocateGoldCoins",
                        new { userId, gameId },
                        commandType: CommandType.StoredProcedure);

                    await conn.ExecuteAsync(command);
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
