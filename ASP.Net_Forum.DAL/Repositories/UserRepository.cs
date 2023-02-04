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

        public bool Create(User entity)
        {
            DbContext.Add(entity);
            DbContext.SaveChanges();

            return true;
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return DbContext.User.ToList();
        }

        public User GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
