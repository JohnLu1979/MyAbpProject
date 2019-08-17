﻿using Abp.AutoMapper;
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
    public class WmtRainAppService : CBaseAppService, IWeatherAppService
    {

        private readonly IRepository<CWeather, int> _weatherRepository;

        public WmtRainAppService(
            IRepository<CWeather, int> weatherRepository

            ) : base()
        {
            this._weatherRepository = weatherRepository;

        }

        public CDataResults<CWeatherDto> GetWeathers(CWeatherInput input)
        {
            //Extract data from DB
            var query = this._weatherRepository.GetAll();

            if (input.pageNumber.HasValue && input.pageNumber.Value > 0 && input.pageSize.HasValue)
            {
                query = query.OrderBy(r => r.Id).Take(input.pageSize.Value * input.pageNumber.Value).Skip(input.pageSize.Value * (input.pageNumber.Value - 1));
            }

            var result = query.ToList().MapTo<List<CWeatherDto>>();

            return new CDataResults<CWeatherDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = query.Count()
            };
        }

        public CDataResult<int> AddWeather(CWeatherInput input) {
            var newWeather = new CWeather()
            {
                Title = input.Title,
                Type = input.Type,
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
