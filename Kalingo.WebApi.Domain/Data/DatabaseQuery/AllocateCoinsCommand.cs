using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class AllocateCoinsCommand
    {
        private readonly string _connectionString;

        public AllocateCoinsCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Execute(MinesBoomSession mbSession)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspAllocateCoins",
                    new
                    {
                        mbSession.UserId,
                        mbSession.GameId,
                        mbSession.GameResult.CoinType,
                        mbSession.GameResult.CoinsWon
                    },
                    commandType: CommandType.StoredProcedure);

                await conn.ExecuteAsync(command);
            }
        }
    }
}
