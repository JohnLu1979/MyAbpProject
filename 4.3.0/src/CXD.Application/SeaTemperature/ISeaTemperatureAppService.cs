using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.SeaTemperature.Dto;
using System.Threading.Tasks;

namespace CXD.SeaTemperature
{
    public interface ISeaTemperatureAppService : IApplicationService
    {
        Task<CDataResults<CSeaTemperatureDto>> GetSeaTemperatureByToday(CSeaTemperatureInput input);
    }
}
