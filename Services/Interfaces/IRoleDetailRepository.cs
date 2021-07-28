using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRoleDetailRepository
    {
        ResponseList<IEnumerable<RoleDetail>> GetRoleDetails(FilterBase filter);
        Task<RoleDetail> GetRoleDetailById(string id);
        string SetRoleDetail(RoleDetail roleDetail);
        Task<string> DeleteRoleDetail(string id);
    }
}
