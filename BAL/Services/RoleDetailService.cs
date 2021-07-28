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
    public class RoleDetailService : IRoleDetailService
    {
        private readonly IRoleDetailRepository _roleDetailRepository;
        private readonly ILogger<RoleDetailService> _logger;

        public RoleDetailService(
            IRoleDetailRepository roleDetailRepository, ILogger<RoleDetailService> logger)
        {
            _roleDetailRepository = roleDetailRepository;
            _logger = logger;
        }

        public Task<string> DeleteRoleDetail(string id)
        {
            try
            {
                return this._roleDetailRepository.DeleteRoleDetail(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<RoleDetail> GetRoleDetailById(string id)
        {
            try
            {
                return this._roleDetailRepository.GetRoleDetailById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<RoleDetail>> GetRoleDetails(FilterBase filter)
        {
            try
            {
                return this._roleDetailRepository.GetRoleDetails(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetRoleDetail(RoleDetail roleDetail)
        {
            try
            {
                return this._roleDetailRepository.SetRoleDetail(roleDetail);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
