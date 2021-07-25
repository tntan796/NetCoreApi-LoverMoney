using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IUserService
    {
        ResponseList<IEnumerable<User>> GetUsers(FilterBase filter);
        Task<User> GetUserById(string id);
        Task<string> SetUser(User user);
        Task<string> DeleteUser(string id);
    }
}
