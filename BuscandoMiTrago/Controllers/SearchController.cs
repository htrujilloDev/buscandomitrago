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


        /// <summary>
        /// Método que realiza una busqueda por nombre de bebida
        /// </summary>
        /// <param name="name"></param>
        /// <returns>lstBuscandoTrago</returns>
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

        /// <summary>
        /// Método que permite buscar por ingrediente
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns>lstBuscandoIngrediente</returns>
        [HttpGet]
        public async Task<IActionResult> SearchByIngredient(string ingredient)
        {
            
            List<VMBuscandoIngrediente> lstBuscandoIngrediente = new List<VMBuscandoIngrediente>();

            var sEndPoint = "https://localhost:7277/api";
            var url = $"{sEndPoint}/Search/SearchByIngredient?ingredient={ingredient}";
        


            HttpResponseMessage response =  _httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var obJson = JsonSerializer.Deserialize<BuscandoIngredientes>(data);
                foreach (var item in obJson.ingredients)
                {
                    var lstObject = new VMBuscandoIngrediente();
                    lstObject.idIngredient   = item.idIngredient;
                    lstObject.strIngredient  = item.strIngredient;
                    lstObject.strDescription = item.strDescription;
                    lstObject.strType        = item.strType;
                    lstObject.strAlcohol     = item.strAlcohol;
                    lstObject.strABV         = item.strABV;

                    lstBuscandoIngrediente.Add(lstObject);
                }


                return View(lstBuscandoIngrediente);

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
