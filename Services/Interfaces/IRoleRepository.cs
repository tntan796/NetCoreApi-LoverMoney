using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRoleRepository
    {
        ResponseList<IEnumerable<Role>> GetRoles(FilterBase filter);
        Task<Role> GetRoleById(string id);
        string SetRole(Role role);
        Task<string> DeleteRole(string id);
    }
}
