using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Kalingo.WebApi.AcceptanceTests.WebApi.Support
{
    public class DbHelper
    {
        private static string _connectionString;

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static async void DeleteUserGames(int gameId)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspDeleteUserGame",
                        new { gameId },
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
