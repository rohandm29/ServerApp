using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetMinesboomSettings
    {
        private readonly string _connectionString;

        public GetMinesboomSettings(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<MinesboomSettings> Execute()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspGetMinesboomSettings",
                        commandType: CommandType.StoredProcedure);

                    var settings = await conn.QueryAsync<MinesboomSettings.Settings>(command);

                    var minesboomSettings = new MinesboomSettings {Setting = settings};

                    return minesboomSettings;
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
