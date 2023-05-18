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
        public AppDbContext _dbContext { get; set; }

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(User entity)
        {
            await _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> Get(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<User> Update(User entity)
        {
             _dbContext.Users.Update(entity);
             await _dbContext.SaveChangesAsync();

             return entity;
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users;
        }
    }
}
