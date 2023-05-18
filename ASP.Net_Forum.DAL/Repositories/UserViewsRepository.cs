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
    public class UserViewsRepository : IUserViewsRepository
    {
        private readonly AppDbContext dbContext;

        public UserViewsRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Create(UserViews entity)
        {
            await dbContext.AddAsync(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(UserViews entity)
        {
            dbContext.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<UserViews> Get(int id)
        {
            return await dbContext.UserViews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<UserViews> GetAll()
        {
            return dbContext.UserViews;
        }

        public async Task<UserViews> Update(UserViews entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
