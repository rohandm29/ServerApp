﻿using System;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Services;

namespace Kalingo.WebApi.Processors
{
    public class UserProcessor
    {
        private readonly UserRepository _repository;

        public UserProcessor(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse> GetUser(UserArgs userArgs)
        {
            try
            {
                var user = await _repository.GetUser(userArgs);

                if (user == null)
                {
                    return UserNotFound();
                }

                if (!Encryption.VerifyHash(userArgs.Password, user.Password))
                {
                    return InvalidUser();
                }

                if (!user.IsActive)
                {
                    return InactiveUser();
                }

                var config = await _repository.GetConfig();

                return ValidUser(user.UserId, user.Gold, user.Silver, user.CountryId, config);
            }
            catch (Exception e)
            {
                return InvalidUser();
            }
        }

        public async Task<int> AddUser(NewUserRequest user)
        {
            try
            {
                var userId = await _repository.AddUser(user);

                return userId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task UpdateUser(UpdateUserRequest updateUser)
        {
            try
            {
                await _repository.UpdateUser(updateUser);
            }
            catch (Exception)
            {
                //Log
            }
        }

        public async Task<int> GetLimit(int userId)
        {
            try
            {
                return await _repository.GetUserPlayCount(userId);
            }
            catch (Exception)
            {
                //log
                return 0;
            }
        }

        private static UserResponse ValidUser(int userId, int gold, int silver, int countryId, Config config)
        {
            var response = new UserResponse(userId, config, gold, silver, countryId)
            {
                Code = UserCodes.Valid
            };

            return response;
        }

        private static UserResponse InvalidUser()
        {
            var response = new UserResponse(0)
            {
                Code = UserCodes.Invalid
            };

            response.Errors.Add("User not valid");

            return response;
        }

        private static UserResponse UserNotFound()
        {
            var response = new UserResponse(0)
            {
                Code = UserCodes.NotFound
            };

            response.Errors.Add("User not found");

            return response;
        }

        private static UserResponse InactiveUser()
        {
            var response = new UserResponse(0)
            {
                Code = UserCodes.Inactive
            };

            response.Errors.Add("User not active");

            return response;
        }
    }
}