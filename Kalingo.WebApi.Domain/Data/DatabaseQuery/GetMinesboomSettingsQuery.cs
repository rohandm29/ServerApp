using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Kalingo.WebApi.Domain.Entity;

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
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
