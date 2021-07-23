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
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ILogger<Device> _logger;

        public DeviceService(
            IDeviceRepository deviceRepository, ILogger<Device> logger)
        {
            _deviceRepository = deviceRepository;
            _logger = logger;
        }
        public Task<BaseValidate> DeleteDevice(string id)
        {
            try
            {
                return this._deviceRepository.DeleteDevice(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Device> GetDeviceById(string id)
        {
            try
            {
                return this._deviceRepository.GetDeviceById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Device>> GetDevices(FilterBase filter)
        {
            try
            {
                return this._deviceRepository.GetDevices(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string SetDevice(Device device)
        {
            try
            {
                return this._deviceRepository.SetDevice(device);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}
