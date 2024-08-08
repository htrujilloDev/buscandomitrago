using BuscandoMiTrago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coctel.BackEnd.Services
{
    public class SearchService: ISearchService
    {
        public SearchService() 
        {

        }
        public async Task<Object> GstSearchByName(string name) 
        {
            var sEndPoint = "www.thecocktaildb.com/api/json";
            var url = $"{sEndPoint}/v1/1/search.php?s={name}";

            try
            {
                using var httpClient = new HttpClient();
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                var response = await httpClient.SendAsync(requestMessage);

                if (response.StatusCode != System.Net.HttpStatusCode.Conflict)
                {
                    var obJson = JsonSerializer.Deserialize<BuscandoTragosResponse>(await response.Content.ReadAsStringAsync());
                    return obJson;
                }


            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "Failed to access EndPoint: " + url);

            }
            return null;
        }
    }
}
