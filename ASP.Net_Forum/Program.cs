using ASP.Net_Forum.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
var conf_builder = new ConfigurationBuilder();
conf_builder.SetBasePath(Directory.GetCurrentDirectory());
conf_builder.AddJsonFile("appsettings.json");
var config = conf_builder.Build();

var connection = config.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 31))));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
