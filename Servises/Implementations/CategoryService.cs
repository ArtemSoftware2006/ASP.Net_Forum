using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Service.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository _categoryRepository { get; set; }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<BaseResponse<bool>> Create(Category userViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> Edit(Category model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Category>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<Category>>> GetAll()
        {
            try
            {
                var categories = _categoryRepository.GetAll().ToList();

                if (categories.Count() != 0)
                {
                    return new BaseResponse<IEnumerable<Category>>
                    {
                        Data = categories,
                        Description = "ok",
                        StatusCode = Domain.Enum.StatusCode.OK,
                    };
                }
                return new BaseResponse<IEnumerable<Category>>
                {
                    StatusCode = Domain.Enum.StatusCode.NotFound,
                    Description = "нет категорий",
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Category>>()
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enum.StatusCode.InternalServerError,
                };
            }
        }
    }
}
