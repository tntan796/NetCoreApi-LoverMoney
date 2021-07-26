using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IPackageService
    {
        ResponseList<IEnumerable<Package>> GetPackages(FilterBasePackage filter);
        Task<Package> GetPackageById(int id);
        Task<int> SetPackage(Package package);
        Task<int> DeletePackage(int id);
    }
}
