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
    public class CategoryRepository : ICategoryRepository
    {
        public AppDbContext AppDbContext { get; set; }

        public CategoryRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public async Task<bool> Create(Category entity)
        {
            await AppDbContext.AddAsync(entity);
            await AppDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Category entity)
        {
            AppDbContext.Remove(entity);
            await AppDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Category> Get(int id)
        {
            return await AppDbContext.Categories.FirstOrDefaultAsync(x => x.id == id);
        }

        public IQueryable<Category> GetAll()
        {
            return AppDbContext.Categories;
        }

        public async Task<Category> Update(Category entity)
        {
            AppDbContext.Update(entity);
            await AppDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
