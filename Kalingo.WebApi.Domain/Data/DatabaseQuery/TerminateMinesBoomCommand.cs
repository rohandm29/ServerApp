using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
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

        public async Task Execute(int gameId, List<int> userSelections, int[] randomSequence)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspTerminateMinesBoom",
                    new
                    {   gameId,
                        @randomSequence = RandomProvider.GetDelimatedSequence(randomSequence),
                        @userSelections = RandomProvider.GetDelimatedSequence(userSelections)
                    },
                    commandType: CommandType.StoredProcedure);

                await conn.ExecuteScalarAsync<int>(command);
            }
        }
    }
}
