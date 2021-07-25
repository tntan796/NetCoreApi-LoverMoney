using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDeviceRepository
    {
        ResponseList<IEnumerable<Device>> GetDevices(FilterBase filter);
        Task<Device> GetDeviceById(string id);
        string SetDevice(Device device);
        Task<string> DeleteDevice(string id);
    }
}
