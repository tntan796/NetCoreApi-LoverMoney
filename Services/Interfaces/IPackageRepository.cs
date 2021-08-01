using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPackageRepository
    {
        ResponseList<IEnumerable<Package>> GetPackages(FilterBasePackage filter);
        Task<Package> GetPackageById(string id);
        Task<string> SetPackage(Package package);
        Task<string> DeletePackage(string id);
    }
}
