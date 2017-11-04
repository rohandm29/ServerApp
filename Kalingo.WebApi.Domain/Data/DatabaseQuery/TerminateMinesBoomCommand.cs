using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class TerminateMinesBoomCommand
    {
        private readonly string _connectionString;

        public TerminateMinesBoomCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Execute(int gameId, string userSelections, int[] randomSequence)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspTerminateMinesBoom",
                        new
                        {
                            @gameId = gameId,
                            @randomSequence = RandomProvider.GetDelimatedSequence(randomSequence),
                            @userSelections = userSelections
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
