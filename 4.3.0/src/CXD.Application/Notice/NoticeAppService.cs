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
        public CDataResult<NoticeListDto> AddNotice(NoticeInput input)
        {
            throw new NotImplementedException();
        }

        public CDataResults<NoticeListDto> GetAll(NoticeInput input)
        {
            throw new NotImplementedException();
        }

        public CDataResult<NoticeListDto> GetNoticeDetail(NoticeInput input)
        {
            throw new NotImplementedException();
        }

        public CDataResult<NoticeListDto> UpdateNotice(NoticeInput input)
        {
            throw new NotImplementedException();
        }
    }
}
