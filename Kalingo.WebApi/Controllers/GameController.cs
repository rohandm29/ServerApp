using System;
using System.Threading.Tasks;
using System.Web.Http;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Ladders;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Processors;

namespace Kalingo.WebApi.Controllers
{
    [RoutePrefix("api/games")]
    public class GameController : ApiController
    {
        private readonly GameProcessor _processor;

        public GameController(GameProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Creates a new game for a user with the given game type.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [Route("join")]
        [HttpPost]
        public async Task<IHttpActionResult> Join([FromBody] NewMinesboomRequest minesboomRequest)
        {
            try
            {
                var gameId = await _processor.ExecuteNewGame(minesboomRequest);

                return Ok(gameId);
            }   
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        /// <summary>
        /// Submit the user's selected answer.
        /// </summary>
        /// <param name="gameArgs"></param>
        /// <returns></returns>
        [Route("submit/MinesBoomSession")]
        [HttpPost]
        public async Task<IHttpActionResult> Submit([FromBody] MinesboomSelectionRequest gameArgs)
        {
            try
            {
                var reuslt = (MinesboomSelectionResponse)await _processor.ExecuteSelection(gameArgs);
                return Ok(reuslt);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        /// <summary>
        /// Submit the user's selected answer.
        /// </summary>
        /// <param name="gameArgs"></param>
        /// <returns></returns>
        [Route("submit/Ladders")]
        [HttpPost]
        public async Task<IHttpActionResult> Submit([FromBody] LaddersGameRequest gameArgs)
        {
            await _processor.ExecuteSelection(gameArgs);
            return Ok();
        }

        /// <summary>
        /// When the game is terminated by user or system.
        /// </summary>
        /// <param name="gameArgs"></param>
        /// <returns></returns>
        [Route("terminate")]
        [HttpPut]
        public async Task<IHttpActionResult> Terminated([FromBody] GameArgs gameArgs)
        {
            await _processor.TerminateGame(gameArgs);
            return Ok();
        }
    }
}
