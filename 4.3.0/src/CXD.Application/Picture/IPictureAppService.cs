using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.Application.Services;
using CXD.Picture.DTO;
using CXD.Base.Dto;
 

namespace CXD.Picture
{
    public interface IPictureAppService : IApplicationService
    {

        Task<CDataResults<PictrueListDto>> GetPictrues(PictureInput input);
        CDataResult<int> Add(PictureInput input);

        CDataResult<int> Delete(PictureInput input);

        //CDataResult<string> UploadImg(PictureInput input);
    }
}
