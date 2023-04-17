using ASP.Net_Forum.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           // Database.EnsureCreated();   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Category>().HasData(
            //    new Category() { Id = 1, Name = "Дизайн" },
            //    new Category() { Id = 2, Name = "Мобильная разработка" },
            //    new Category() { Id = 3, Name = "Web" },
            //    new Category() { Id = 4, Name = "Desktop" },
            //    new Category() { Id = 5, Name = "Big Date" });
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserMark> UserMarks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoteTags> NoteTags{ get; set;}
    }
}
