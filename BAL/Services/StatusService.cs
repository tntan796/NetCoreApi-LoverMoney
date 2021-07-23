using BLL.Intefaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ILogger<Status> _logger;

        public StatusService(
            IStatusRepository statusRepository, ILogger<Status> logger)
        {
            _statusRepository = statusRepository;
            _logger = logger;
        }

        public Task<BaseValidate> DeleteStatus(int id)
        {
            try
            {
                return this._statusRepository.DeleteStatus(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Status> GetStatusById(int id)
        {
            try
            {
                return this._statusRepository.GetStatusById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Status>> GetStatus(FilterBase filter)
        {
            try
            {
                return this._statusRepository.GetStatus(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<string> SetStatus(Status status)
        {
            try
            {
                return this._statusRepository.SetStatus(status);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
