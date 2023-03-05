using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.DAL.Repositories
{
	public class NoteRepository : INoteRepository
	{
		public AppDbContext DbContext { get; set; }
		public NoteRepository(AppDbContext dbContext)
		{
			DbContext = dbContext;
		}
		public async Task<bool> Create(Note entity)
		{
			DbContext.Add(entity);
			await DbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> Delete(Note entity)
		{
			DbContext.Remove(entity);
			await DbContext.SaveChangesAsync();

			return true;
		}

		public async Task<Note> Get(int id)
		{
			return DbContext.Notes.FirstOrDefault(x => x.Id == id);
		}
		public async Task<Note> Update(Note entity)
		{
			DbContext.Notes.Update(entity);
			await DbContext.SaveChangesAsync();

			return entity;
		}

		public IQueryable<Note> GetAll()
		{
			return DbContext.Notes;
		}

		public Task<bool> Create(Migrations.Note entity)
		{
			throw new NotImplementedException();
		}

	}
}
