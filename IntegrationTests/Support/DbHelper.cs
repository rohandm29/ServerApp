using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace IntegrationTests.Support
{
    public class DbHelper
    {
        private static string _connectionString;

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UserGameData> GetUserGameMinesBoom(int gameId)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspUserGame",
                        new { gameId },
                        commandType: CommandType.StoredProcedure);
                    
                    var userGame = await conn.QueryAsync<UserGameData>(command);

                    return userGame.First();
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
