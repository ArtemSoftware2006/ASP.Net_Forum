﻿using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.DAL.Migrations;
using ASP.Net_Forum.Domain.Entity;
using ASP.Net_Forum.Domain.Response;
using ASP.Net_Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Service.Implementations
{
	public class TagService : ITagService
	{
		public ITagRepository _tagRepository { get; set; }

		public TagService(ITagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}
		public async Task<BaseResponse<bool>> Create(Tag model)
		{
			try
			{
				//Приветедение типов модели и Tag

				await _tagRepository.Create(model);

				return new BaseResponse<bool>()
				{
					Data = true,
					Description = "OK",
					StatusCode = Domain.Enum.StatusCode.OK,
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>
				{
					StatusCode = Domain.Enum.StatusCode.InternalServerError,
					Data = false,
					Description = ex.Message,
				};
			}
		}

		public Task<BaseResponse<bool>> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<BaseResponse<bool>> Edit(int id, Tag model)
		{
			throw new NotImplementedException();
		}

		public async Task<BaseResponse<Tag>> Get(int id)
		{
			try
			{
				var tag = await _tagRepository.Get(id);
				if (tag != null)
				{
					return new BaseResponse<Tag>
					{
						Data = tag,
						StatusCode = Domain.Enum.StatusCode.OK,
						Description = "OK",
					};
				}
				return new BaseResponse<Tag>
				{
					StatusCode = Domain.Enum.StatusCode.NotFound,
					Description = $"Тэга с id {id} нет",
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<Tag>
				{
					StatusCode = Domain.Enum.StatusCode.InternalServerError,
					Description = ex.Message,
				};
			}
		}

		public async Task<BaseResponse<IEnumerable<Tag>>> GetAllTags()
		{
			try
			{
				var tags = _tagRepository.GetAll();

				if (tags.Count() != 0)
				{
					 return new BaseResponse<IEnumerable<Tag>>
					 {
						Data = tags,
						StatusCode = Domain.Enum.StatusCode.OK,
						Description = "OK",
					 };
				}
				return new BaseResponse<IEnumerable<Tag>>
				{
					Data = tags,
					StatusCode = Domain.Enum.StatusCode.NotFound,
					Description = "Нет тэгов",
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<IEnumerable<Tag>>
				{
					StatusCode = Domain.Enum.StatusCode.InternalServerError,
					Description = ex.Message
				};
			}
		}
	}
}
