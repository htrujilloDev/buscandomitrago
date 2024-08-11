using BuscandoMiTrago.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Diagnostics;
using BuscandoMiTrago.Models.ViewModels;

namespace BuscandoMiTrago.Controllers
{
    public class SearchController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44394/api");
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public SearchController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(string name)
        {
            //string name = "Mojito";
            List<VMBuscandoTragosResponse> lstBuscandoTrago= new List<VMBuscandoTragosResponse>();

            var sEndPoint = "https://localhost:7277/api";
            var url = $"{sEndPoint}/Search/SearchByName?name={name}";

            
            HttpResponseMessage response = _httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var obJson = JsonSerializer.Deserialize<BuscandoTragosResponse>(data);
                foreach (var item in obJson.drinks)
                {
                    var lstObject = new VMBuscandoTragosResponse();
                        lstObject.idDrink= item.idDrink;
                        lstObject.strDrink = item.strDrink;
                        lstObject.strCategory = item.strCategory;
                        lstObject.strDrinkAlternate = item.strDrinkAlternate;
                        lstObject.strAlcoholic = item.strAlcoholic;
                        lstObject.strGlass = item.strGlass;
                        lstObject.strInstructions= item.strInstructions;
                        lstObject.strDrinkThumb = item.strDrinkThumb;
                        lstBuscandoTrago.Add(lstObject);
                }



              
                return View(lstBuscandoTrago);

            }
           return View(null);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
