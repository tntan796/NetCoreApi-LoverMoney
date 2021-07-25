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
        Task<string> SetUser(User user);
        Task<string> DeleteUser(string id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByPhone(string phone);

    }
}
