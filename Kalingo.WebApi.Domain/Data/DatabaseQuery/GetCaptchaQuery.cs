using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Captcha;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class GetCaptchaQuery
    {
        private readonly string _connectionString;

        public GetCaptchaQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<CaptchaResponse> Execute(int id, CaptchaArgs captchaArgs)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    var command = new CommandDefinition(
                        "uspGetCaptcha",
                        new {@id = id, @gameId = captchaArgs.GameId},
                        commandType: CommandType.StoredProcedure);

                    var captcha = await conn.QueryAsync<CaptchaResponse>(command);
                    
                    return captcha.First();
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
