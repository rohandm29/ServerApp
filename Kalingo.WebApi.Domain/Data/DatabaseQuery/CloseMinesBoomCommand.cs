using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.WebApi.Domain.Engine;
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
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspCloseMinesBoom",
                    new
                    {
                        @userId = mb.UserId,
                        @gameId = mb.GameId,
                        @win = mb.GameResult.HasWon,
                        @randomSequence = RandomProvider.GetDelimatedSequence(mb.GameState.RandomSequence),
                        @userSelections = RandomProvider.GetDelimatedSequence(mb.GameState.UserSelections)
                    },
                    commandType: CommandType.StoredProcedure);

                await conn.ExecuteScalarAsync<int>(command);
            }
        }
    }
}
