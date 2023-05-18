using ASP.Net_Forum.DAL;
using ASP.Net_Forum.DAL.Interfaces;
using ASP.Net_Forum.DAL.Repositories;
using ASP.Net_Forum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.Net_Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}