using BLL.Intefaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<User> _logger;

        public UserService(
            IUserRepository userRepository, ILogger<User> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public Task<string> DeleteUser(string id)
        {
            try
            {
                return this._userRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<User> GetUserById(string id)
        {
            try
            {
                return this._userRepository.GetUserById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<User>> GetUsers(FilterBase filter)
        {
            try
            {
                return this._userRepository.GetUsers(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<string> SetUser(User user)
        {
            try
            {
                return this._userRepository.SetUser(user);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
