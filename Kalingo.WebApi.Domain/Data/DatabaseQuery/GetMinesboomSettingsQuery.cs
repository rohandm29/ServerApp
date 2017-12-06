using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Kalingo.Games.Contract.Entity.MinesBoom;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetMinesboomSettingsQuery
    {
        private readonly string _connectionString;

        public GetMinesboomSettingsQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Settings> Execute()
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspGetMinesboomSettings",
                    commandType: CommandType.StoredProcedure);

                var settings = conn.Query<Settings>(command);

                return settings;
            }
        }
    }
}
