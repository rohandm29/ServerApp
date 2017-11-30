using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity;
using Kalingo.WebApi.Domain.Engine;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class TerminateMinesBoomCommand
    {
        private readonly string _connectionString;

        public TerminateMinesBoomCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Execute(string userId, int gameId, int[] userSelection, List<int> randomSequence, bool expired)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspCloseMinesBoom",
                    new
                    {
                        userId,
                        gameId,
                        @win = false,
                        @randomSequence = RandomProvider.GetDelimatedSequence(randomSequence),
                        @userSelections = RandomProvider.GetDelimatedSequence(userSelection),
                        @Expired = expired,
                    },
                    commandType: CommandType.StoredProcedure);

                await conn.ExecuteScalarAsync<int>(command);
            }
        }
    }
}
