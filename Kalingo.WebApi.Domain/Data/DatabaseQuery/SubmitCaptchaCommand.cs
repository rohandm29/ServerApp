using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity.Captcha;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class SubmitCaptchaCommand
    {
        private readonly string _connectionString;

        public SubmitCaptchaCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> Execute(CaptchaAnswerRequest captchaAnswer)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspProcessCaptcha",
                    new {@captchaId = captchaAnswer.CaptchaId, @gameId = captchaAnswer.GameId, @answer = captchaAnswer.Answer},
                    commandType: CommandType.StoredProcedure);

                var result = await conn.QueryAsync<bool>(command);

                return result.FirstOrDefault();
            }
        }
    }
}
