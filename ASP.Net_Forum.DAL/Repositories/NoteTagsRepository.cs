using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.DAL.Repositories
{
	public class NoteTagsRepository : INoteTagsRepository
	{
		public AppDbContext _dbContext { get; set; }

		public NoteTagsRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<bool> Create(NoteTags entity)
		{
			_dbContext.Add(entity);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Delete(NoteTags entity)
		{
			_dbContext.Remove(entity);
			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<NoteTags> Get(int id)
		{
			return await _dbContext.NoteTags.FirstOrDefaultAsync(x => x.Id == id);
		}

		public IQueryable<NoteTags> GetAll()
		{
			return _dbContext.NoteTags;
		}

		public async Task<NoteTags> Update(NoteTags entity)
		{
			_dbContext.Update(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}
	}
}
