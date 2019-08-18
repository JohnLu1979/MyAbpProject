using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.Notice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Notice
{
    public interface INoticeAppService : IApplicationService
    {
        CDataResults<NoticeListDto> GetAll(NoticeInput input);
        CDataResult<NoticeListDto> GetNoticeDetail(NoticeInput input);
        CDataResult<NoticeListDto> UpdateNotice(NoticeInput input);
        CDataResult<int> AddNotice(NoticeInput input);
        CDataResult<int> NoticeDelete(NoticeInput input);
    }
}
