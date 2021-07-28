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
    public class RoleService: IRoleService
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleService> _logger;

        public RoleService(
            IRoleService roleService, ILogger<RoleService> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        public Task<string> DeleteRole(string id)
        {
            try
            {
                return this._roleService.DeleteRole(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Role> GetRoleById(string id)
        {
            try
            {
                return this._roleService.GetRoleById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Role>> GetRoles(FilterBase filter)
        {
            try
            {
                return this._roleService.GetRoles(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetRole(Role role)
        {
            try
            {
                return this._roleService.SetRole(role);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
