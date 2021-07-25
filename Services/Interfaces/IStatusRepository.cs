using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStatusRepository
    {
        ResponseList<IEnumerable<Status>> GetStatus(FilterBase filter);
        Task<Status> GetStatusById(int id);
        Task<string> SetStatus(Status status);
        Task<int> DeleteStatus(int id);
    }
}
