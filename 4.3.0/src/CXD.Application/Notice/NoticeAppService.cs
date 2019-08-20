using Abp.Domain.Repositories;
using CXD.Base;
using CXD.Base.Dto;
using CXD.Notice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CXD.Entities;
using Abp.AutoMapper;

namespace CXD.Notice
{

    public class NoticeAppService : CBaseAppService, INoticeAppService
    {
        public readonly IRepository<CNotice, int> _noticeRepository;

        //private readonly IRepository<CWeather, int> _weatherRepository;
        public NoticeAppService(
         IRepository<CNotice, int> noticeRepository
            ) : base()
        {
            this._noticeRepository = noticeRepository;
        }

        public CDataResults<NoticeListDto> GetAll(NoticeInput input)
        {
            var query = this._noticeRepository.GetAll();
            if (input.Title != null)
            {
                query = query.Where(p => p.Title.Contains(input.Title));
            }
            if (input.pageNumber.HasValue && input.pageNumber.Value > 0 && input.pageSize.HasValue)
            {
                query = query.OrderBy(r => r.Id).Take(input.pageSize.Value * input.pageNumber.Value).Skip(input.pageSize.Value * (input.pageNumber.Value - 1));
            }
            var result = query.ToList().MapTo<List<NoticeListDto>>();

            return new CDataResults<NoticeListDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = query.Count()
            };
        }

        public CDataResult<NoticeListDto> GetNoticeDetail(NoticeInput input)
        {
            var item = this._noticeRepository.Get(input.Id);
            if (item == null)
            {
                return new CDataResult<NoticeListDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = null,
                    Data = null
                };
            }
            else
            {
                return new CDataResult<NoticeListDto>()
                {
                    IsSuccess = true,
                    ErrorMessage = null,
                    Data = item.MapTo<NoticeListDto>()
                };
            }
        }
        public CDataResult<NoticeListDto> UpdateNotice(NoticeInput input)
        {
            var result = new CDataResult<NoticeListDto>()
            {
                IsSuccess = false,
                ErrorMessage = null,
                Data = null
            };
            var notice = this._noticeRepository.Get(input.Id);
            if (notice == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                notice.Title = input.Title;
                notice.NewsAuthor = input.NewsAuthor;
                notice.DisplayIndex = input.DisplayIndex;
                notice.NewsContent = input.NewsContent;
                notice.Id = input.Id;
            }

            var updateNotice = this._noticeRepository.Update(notice);

            if (updateNotice == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                result.IsSuccess = true;
                result.Data = updateNotice.MapTo<NoticeListDto>();
            }
            return result;
        }

        public CDataResult<int> AddNotice(NoticeInput input)
        {
            var newNotice = new CNotice()
            {
                Title = input.Title,
                NewsAuthor = input.NewsAuthor,
                DisplayIndex = input.DisplayIndex,
                NewsContent = input.NewsContent
            };

            var newNoticeId = this._noticeRepository.InsertAndGetId(newNotice);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = newNoticeId
            };
        }

        public CDataResult<int> NoticeDelete(NoticeInput input)
        {
            this._noticeRepository.Delete(input.Id);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = 1
            };
        }
    }
}
