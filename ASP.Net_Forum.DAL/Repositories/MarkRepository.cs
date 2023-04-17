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
	public class MarkRepository : IMarkRepository
	{
		private readonly AppDbContext appDbContext;

		public MarkRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task<bool> Create(UserMark entity)
		{
			await appDbContext.AddAsync(entity);
			await appDbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> Delete(UserMark entity)
		{
			appDbContext.Remove(entity);
			await appDbContext.SaveChangesAsync();

			return true;
		}

		public async Task<UserMark> Get(int id)
		{
			return await appDbContext.UserMarks.FirstOrDefaultAsync(x => x.Id == id);
		}

		public IQueryable<UserMark> GetAll()
		{
			return appDbContext.UserMarks;
		}

		public async Task<UserMark> Update(UserMark entity)
		{
			appDbContext.Update(entity);
			await appDbContext.SaveChangesAsync();

			return entity;
		}
	}
}
