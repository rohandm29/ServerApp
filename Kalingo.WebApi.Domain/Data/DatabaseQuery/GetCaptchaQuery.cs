using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetCaptchaQuery
    {
        private readonly string _connectionString;

        public GetCaptchaQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<CaptchaResponse> Execute(CaptchaArgs captchaArgs)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspGetCaptcha",
                        new {@id = 2},
                        commandType: CommandType.StoredProcedure);

                    var captcha = await conn.QueryAsync<string>(command);

                    return new CaptchaResponse(2, captcha.FirstOrDefault());
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
