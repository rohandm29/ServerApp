using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kalingo.Games.Contract.Entity.Captcha;

namespace Kalingo.WebApi.Domain.Data.DatabaseQuery
{
    public class AddCaptchaCommand
    {
        private readonly string _connectionString;

        public AddCaptchaCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Execute(int id, CaptchaRequest captchaArgs)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var command = new CommandDefinition(
                    "uspAddCaptcha",
                    new {id, @gameId = captchaArgs.GameId},
                    commandType: CommandType.StoredProcedure);

                await conn.ExecuteAsync(command);
            }
        }
    }
}
