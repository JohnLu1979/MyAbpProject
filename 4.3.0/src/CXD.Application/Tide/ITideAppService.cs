using Abp.Application.Services;
using CXD.Base.Dto;
using CXD.Tide.Dto;
using System.Threading.Tasks;

namespace CXD.Tide
{
    public interface ITideAppService : IApplicationService
    {
        Task<CDataResults<CTideDto>> GetTides(CTideInput input);
        CDataResult<int> AddTide(CTideInput input);
        CDataResult<CTideDto> UpdateTide(CTideInput input);
        CDataResult<int> DeleteTide(CTideInput input);
        CDataResult<CTideDto> GetTide(CTideInput input);
        CDataResult<string> ExportTides();
        CDataResult<bool> ImportTides(CTideInput input);
    }
}
