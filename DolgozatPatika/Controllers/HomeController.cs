using DolgozatPatika.Models;
using DolgozatPatika.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DolgozatPatika.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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
        public IActionResult GetAll()
        {
            List<Gyogyszer> gyogyszer = new GyogyszerService().GetAllGyogyszer();
            return View(gyogyszer);
        }

        public IActionResult GetById(int id)
        {
            Gyogyszer valasztottcustomer = new GyogyszerService().GetByIdGogyszer(id);
            return View(valasztottcustomer);
        }
    }
}
