using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IStatusService
    {
        ResponseList<IEnumerable<Status>> GetStatus(FilterBase filter);
        Task<Status> GetStatusById(int id);
        Task<string> SetStatus(Status status);
        Task<int> DeleteStatus(int id);
    }
}
