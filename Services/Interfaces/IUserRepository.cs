using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        ResponseList<IEnumerable<User>> GetUsers(FilterBase filter);
        Task<User> GetUserById(string id);
        string SetUser(User user);
        Task<BaseValidate> DeleteUser(string id);
    }
}
