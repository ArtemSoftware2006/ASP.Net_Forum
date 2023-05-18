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
    public class UserRepository : IUserRepository
    {
        public AppDbContext DbContext { get; set; }

        public UserRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<bool> Create(User entity)
        {
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            DbContext.Remove(entity);
            await DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> Get(int id)
        {
            return await DbContext.Users.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<User> GetByLogin(string login)
        {
            return await DbContext.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<User> Update(User entity)
        {
             DbContext.Users.Update(entity);
             await DbContext.SaveChangesAsync();

             return entity;
        }

        public IQueryable<User> GetAll()
        {
            return DbContext.Users;
        }
    }
}
