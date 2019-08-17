using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.Weather.Dto;

namespace CXD.Weather
{
    public interface IWeatherAppService : IApplicationService
    {
        CDataResults<CWeatherDto> GetWeathers(CWeatherInput input);
        CDataResult<int> AddWeather(CWeatherInput input);
        CDataResult<CWeatherDto> UpdateWeather(CWeatherInput input);
        CDataResult<int> DeleteWeather(CWeatherInput input);
        CDataResult<CWeatherDto> GetWeather(CWeatherInput input);
    }
}
