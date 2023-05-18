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
	public class TagRepository : ITagRepository
	{
		public AppDbContext _dbContext { get; set; }

		public TagRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> Create(Tag entity)
		{
			_dbContext.Tags.Add(entity);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Delete(Tag entity)
		{
			_dbContext.Tags.Remove(entity);
			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<Tag> Get(int id)
		{
			return  await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
		}

		public IQueryable<Tag> GetAll()
		{
			return _dbContext.Tags;
		}

		public async Task<Tag> Update(Tag entity)
		{
			_dbContext.Tags.Update(entity);
			await _dbContext.SaveChangesAsync();

			return entity;
		}
	}
}
