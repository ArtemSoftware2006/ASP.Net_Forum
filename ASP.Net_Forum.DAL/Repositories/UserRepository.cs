using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public AppDbContext DbContext { get; set; }

        public async Task<bool> Create(User entity)
        {
            DbContext.Add(entity);
            DbContext.SaveChanges();

            return true;
        }

        public Task<bool> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return DbContext.User.ToList();
        }

        public Task<User> GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
