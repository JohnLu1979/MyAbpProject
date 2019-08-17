using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.Weather.Dto;
using System.Threading.Tasks;

namespace CXD.Weather
{
    public interface IWeatherAppService : IApplicationService
    {
        Task<CDataResults<CWeatherDto>> GetWeathers(CWeatherInput input);
        CDataResult<int> AddWeather(CWeatherInput input);
        CDataResult<CWeatherDto> UpdateWeather(CWeatherInput input);
        CDataResult<int> DeleteWeather(CWeatherInput input);
        CDataResult<CWeatherDto> GetWeather(CWeatherInput input);
    }
}
