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
            DbContext.SaveChanges();

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
            return await DbContext.User.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return DbContext.User.ToList();
        }

        public async Task<User> GetByLogin(string login)
        {
            return await DbContext.User.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
