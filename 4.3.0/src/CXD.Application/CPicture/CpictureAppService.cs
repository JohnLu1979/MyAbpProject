using Abp.AutoMapper;
using Abp.Domain.Repositories;
using CXD.Base;
using CXD.Base.Dto;
using CXD.CPictureService.Dto;
using CXD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Drawing;
using MimeKit.Encodings;

namespace CXD.CPictureService
{
    public class CpictureAppService : CBaseAppService, ICpictureAppService
    {
        private readonly IRepository<CXD.Entities.CPicture, int> _pictureRepository;
        public CpictureAppService(IRepository<CXD.Entities.CPicture, int> pictureRepository) : base()
        {
            this._pictureRepository = pictureRepository;
        }

        public Task<CDataResults<CPictureListDto>> GetPictrues(CPictureInput input)
        {
            var query = this._pictureRepository.GetAll();
            if (!string.IsNullOrWhiteSpace(input.Title))
            {
                query = query.Where(p => p.Title.Contains(input.Title) || p.Title.Contains(input.Title));
            }
            var total = query.Count();
            if (input.pageNumber.HasValue && input.pageNumber.Value > 0 && input.pageSize.HasValue)
            {
                query = query.OrderByDescending(r => r.Id).Take(input.pageSize.Value * input.pageNumber.Value).Skip(input.pageSize.Value * (input.pageNumber.Value - 1));
            }
            var result = query.ToList().MapTo<List<CPictureListDto>>();

            return Task.FromResult(new CDataResults<CPictureListDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = total
            });
        }

        public CDataResult<int> Add(CPictureInput input)
        {
            var query = this._pictureRepository.GetAll().Where(r => r.Title == input.Title);
            if (query.Count() > 0)
            {
                return new CDataResult<int>()
                {
                    IsSuccess = false,
                    ErrorMessage = "图片名称已存在！",
                    Data = 0
                };
            }
            var newPicture = new CPicture()
            {
                Title = input.Title,
                ImgUrl = input.ImgUrl

            };

            var newPictureId = this._pictureRepository.InsertAndGetId(newPicture);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = newPictureId
            };
        }

        public CDataResult<int> Update(CPictureInput input)
        {
            var result = new CDataResult<int>()
            {
                IsSuccess = false,
                ErrorMessage = null,
                Data = 0
            };
            var picture = this._pictureRepository.Get(input.Id);
            if (picture == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                picture.Title = input.Title;
                picture.ImgUrl = input.ImgUrl;
                picture.Id = input.Id;
            }

            var updatePicture = this._pictureRepository.Update(picture);

            if (updatePicture == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                result.IsSuccess = true;
                result.Data = 1;
            }
            return result;
        }

        public CDataResult<int> Delete(CPictureInput input)
        {
            this._pictureRepository.Delete(input.Id);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = 1
            };
        }


        public CDataResult<string> UploadImg(CPictureInput input)
        {
            //string url = "data:image/jpeg;base64," + input.File_Base64;
            if (!String.IsNullOrEmpty(input.File_Base64))
            {
                var fileSize = input.File_Base64.Count();
                //string extendName = "jpeg";
                var newFileName = GenerateNewFileName(input.File_Base64.Length % 1000 * 1000);
                var url = GetFileURL(System.Configuration.ConfigurationManager.AppSettings["UploadFilesPath"], newFileName);
                newFileName = GetFilePath(System.Configuration.ConfigurationManager.AppSettings["UploadFilesPath"], newFileName);

                if (!Base64StringToFile(input.File_Base64, newFileName))
                {
                    return new CDataResult<string>()
                    {
                        IsSuccess = true,
                        ErrorMessage = null,
                        Data = ""
                    };
                }
                else
                {
                    return new CDataResult<string>()
                    {
                        IsSuccess = true,
                        ErrorMessage = null,
                        Data = url
                    };
                }
            }
            return new CDataResult<string>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = ""
            };
        }


       public CDataResult<CPictureListDto> GetPicDetail(CPictureInput input)
        {
            var item = this._pictureRepository.Get(input.Id);
            if (item == null)
            {
                return new CDataResult<CPictureListDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = null,
                    Data = null
                };
            }
            else
            {
                return new CDataResult<CPictureListDto>()
                {
                    IsSuccess = true,
                    ErrorMessage = null,
                    Data = item.MapTo<CPictureListDto>()
                };
            }
        }
    }
}
