using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class CloseMinesBoomCommand
    {
        private readonly string _connectionString;

        public CloseMinesBoomCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Execute(MinesBoomSession mb)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspCloseMinesBoom",
                        new
                        {
                            @gameId = mb.GameId,
                            @win = mb.GameResult.HasWon,
                            @userSelections = mb.GameState.UserSelections
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
