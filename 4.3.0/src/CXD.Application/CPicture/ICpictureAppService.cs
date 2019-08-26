using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.CPictureService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.CPictureService
{
   public interface ICpictureAppService: IApplicationService
    {
        Task<CDataResults<CPictureListDto>> GetPictrues(CPictureInput input);
        CDataResult<int> Add(CPictureInput input);

        CDataResult<int> Delete(CPictureInput input);

        CDataResult<string> UploadImg(CPictureInput input);
    }
}
