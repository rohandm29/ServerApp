using System;
using System.Threading;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Entity;
using Kalingo.WebApi.Domain.Services;
using NLog;
using Kalingo.WebApi.Domain;

namespace Kalingo.WebApi.Processors
{
    public class UserProcessor
    {
        private readonly UserRepository _repository;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

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

                var config = await _repository.GetConfig(user.CountryId);

                return ValidUser(user, config);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return InvalidUser();
            }
        }

        public async Task<UserResponse> AddFbUser(FbUser fbUser)
        {
            try
            {
                var userEntity = await _repository.AddUser(fbUser);

                var config = await _repository.GetConfig(userEntity.CountryId);

                return ValidUser(userEntity, config);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return InvalidUser();
            }
        }

        public async Task<UserResponse> GetFbUser(string userName)
        {
            var user = await _repository.GetFbUser(userName);
            try
            {
                if (user == null)
                {
                    return UserNotFound();
                }

                if (!user.IsActive)
                {
                    return InactiveUser();
                }

                var config = await _repository.GetConfig(user.CountryId);

                return ValidUser(user, config);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return InvalidUser();
            }
        }

        public async Task<UserResponse> AddUser(NewUserRequest user)
        {
            try
            {
                var userEntity = await _repository.AddUser(user);

                var config = await _repository.GetConfig(user.CountryId);

                return ValidUser(userEntity, config);

            }
            catch (Exception e)
            {
                Log.Error(e);
                return InvalidUser();
            }
        }

        public async Task UpdateUser(UpdateUserRequest updateUser)
        {
            try
            {
                await _repository.UpdateUser(updateUser);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public async Task<int> GetLimit(int userId)
        {
            try
            {
                return await _repository.GetUserPlayCount(userId);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return 0;
            }
        }

        private static UserResponse ValidUser(UserEntity user, Config config)
        {
            var response = new UserResponse(user.UserId, config, user.Gold, user.Silver, user.CountryId)
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