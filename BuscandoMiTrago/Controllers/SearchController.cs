using BuscandoMiTrago.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuscandoMiTrago.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public SearchController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
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
