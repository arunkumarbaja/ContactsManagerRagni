using System.Diagnostics;
using CRUD.Models;
using CRUD.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IEmployeService _employeService;
        public HomeController(ILogger<HomeController> logger, IEmployeService employeService)
        {
            _logger = logger;
            _employeService = employeService;
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
