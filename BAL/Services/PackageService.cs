using BLL.Intefaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packagekRepository;
        private readonly ILogger<Package> _logger;

        public PackageService(
            IPackageRepository packagekRepository, ILogger<Package> logger)
        {
            _packagekRepository = packagekRepository;
            _logger = logger;
        }

        public Task<int> DeletePackage(int id)
        {
            try
            {
                return this._packagekRepository.DeletePackage(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Package> GetPackageById(int id)
        {
            try
            {
                return this._packagekRepository.GetPackageById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Package>> GetPackages(FilterBase filter)
        {
            try
            {
                return this._packagekRepository.GetPackages(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<int> SetPackage(Package package)
        {
            try
            {
                return this._packagekRepository.SetPackage(package);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
