using System.Data;
using System.Data.SqlClient;
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

        public async Task<int> Execute(int userId, string getDelimatedSequence)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspCreateMinesBoom",
                    new {userId, getDelimatedSequence},
                    commandType: CommandType.StoredProcedure);

                var gameId = await conn.ExecuteScalarAsync<int>(command);

                return gameId;
            }
        }
    }
}
