using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CXD.Base;
using CXD.Base.Dto;
using CXD.Entities;
using CXD.Weather;
using CXD.Weather.Dto;

namespace CXD.WmtRain
{
    public class WeatherAppService : CBaseAppService, IWeatherAppService
    {

        private readonly IRepository<CWeather, int> _weatherRepository;

        public WeatherAppService(
            IRepository<CWeather, int> weatherRepository

            ) : base()
        {
            this._weatherRepository = weatherRepository;

        }

        public Task<CDataResults<CWeatherDto>> GetWeathers(CWeatherInput input)
        {
            //Extract data from DB
            var query = this._weatherRepository.GetAll();
            if (!string.IsNullOrEmpty(input.Title))
            {
                query = query.Where(r => r.Title.Contains(input.Title));
            }
            if (input.Type.HasValue) {
                query = query.Where(r => r.Type == input.Type);
            }
            var total = query.Count();
            if (input.pageNumber.HasValue && input.pageNumber.Value > 0 && input.pageSize.HasValue)
            {
                query = query.OrderByDescending(r => r.Id).Take(input.pageSize.Value * input.pageNumber.Value).Skip(input.pageSize.Value * (input.pageNumber.Value - 1));
            }
            else {
                query = query.OrderByDescending(r => r.Id);
            }

            var result = query.ToList().MapTo<List<CWeatherDto>>();

            return Task.FromResult(new CDataResults<CWeatherDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = total
            });
        }

        public CDataResult<int> AddWeather(CWeatherInput input) {
            var newWeather = new CWeather()
            {
                Title = input.Title,
                Type = input.Type.Value,
                Content = input.Content
            };

            var newWeatherId = this._weatherRepository.InsertAndGetId(newWeather);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = newWeatherId
            };
        }

        public CDataResult<CWeatherDto> UpdateWeather(CWeatherInput input)
        {
            var result = new CDataResult<CWeatherDto>()
            {
                IsSuccess = false,
                ErrorMessage = null,
                Data = null
            };
            var weather = this._weatherRepository.Get(input.Id);
            if (weather == null) {
                result.IsSuccess = false;
            }
            weather.Content = input.Content;
            weather.Title = input.Title;
            weather.Type = input.Type.Value;

            var updatedWeather = this._weatherRepository.Update(weather);

            if (updatedWeather == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                result.IsSuccess = true;
                result.Data = updatedWeather.MapTo<CWeatherDto>();
            }
            return result;
        }

        public CDataResult<int> DeleteWeather(CWeatherInput input) {
            this._weatherRepository.Delete(input.Id);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = 1
            };
        }

        public CDataResult<CWeatherDto> GetWeather(CWeatherInput input)
        {
            var weather = this._weatherRepository.Get(input.Id);
            if (weather == null)
            {
                return new CDataResult<CWeatherDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = null,
                    Data = null
                };
            }
            else
            {
                return new CDataResult<CWeatherDto>()
                {
                    IsSuccess = true,
                    ErrorMessage = null,
                    Data = weather.MapTo<CWeatherDto>()
            };
            }
        }
      

    }

}
