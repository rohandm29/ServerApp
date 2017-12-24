﻿using System;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain;
using Kalingo.WebApi.Domain.Exceptions;
using Kalingo.WebApi.Domain.Facades;

namespace Kalingo.WebApi.Processors
{
    public class GameProcessor
    {
        private readonly MinesBoomFacade _minesBoomFacade;

        public GameProcessor(MinesBoomFacade minesBoomFacade)
        {
            _minesBoomFacade = minesBoomFacade;
        }

        public async Task<NewMinesboomResponse> ExecuteNewGame(NewMinesboomRequest minesboomRequest)
        {
            var newMinesboomResponse = await _minesBoomFacade.ProcessNewGame(minesboomRequest);

            return newMinesboomResponse;
        }

        public async Task<GameResult> ExecuteSelection(GameArgs gameArgs)
        {
            // can be any type of gameresult
            try
            {
                dynamic gameResult;

                switch (gameArgs.GameTypeId)
                {
                    case 1:
                        gameResult = await _minesBoomFacade.ProcessSelection((MinesboomSelectionRequest) gameArgs);
                        break;

                    case 2:
                        gameResult = default(GameResult);
                        break;

                    default:
                        gameResult = default(GameResult);
                        break;
                }

                return gameResult;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return default(GameResult);
            }
        }

        public async Task TerminateGame(GameArgs gameArgs)
        {
            try
            {
                switch (gameArgs.GameTypeId)
                {
                    case 1:
                        await _minesBoomFacade.TerminateGame(gameArgs, false);
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}