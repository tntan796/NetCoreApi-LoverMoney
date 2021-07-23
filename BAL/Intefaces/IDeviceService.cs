using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IDeviceService
    {
        ResponseList<IEnumerable<Device>> GetDevices(FilterBase filter);
        Task<Device> GetDeviceById(string id);
        string SetDevice(Device device);
        Task<BaseValidate> DeleteDevice(string id);
    }
}
