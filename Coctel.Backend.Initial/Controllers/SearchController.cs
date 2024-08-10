using Azure;
using Coctel.BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coctel.Backend.Initial.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService) 
        {
            this.searchService = searchService;
        }


        [HttpGet]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SearchByName(string name)
        {          
               var response = await searchService.GstSearchByName(name);

            return Ok(response);
        }
    }
}
