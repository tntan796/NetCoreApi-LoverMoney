using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IPackageService
    {
        ResponseList<IEnumerable<Package>> GetPackages(FilterBasePackage filter);
        Task<Package> GetPackageById(string id);
        Task<string> SetPackage(Package package);
        Task<string> DeletePackage(string id);
    }
}
