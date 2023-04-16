﻿using ASP.Net_Forum.Domain.Entity;
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
        public ICategoryService _categoryService { get; set; }

        public CategoryService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
                var categories = _categoryService.GetAll();

                if (!categories.Co)
                {

                }
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
