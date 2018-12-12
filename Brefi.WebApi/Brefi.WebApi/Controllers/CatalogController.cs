using Brefi.Services;
using Brefi.Services.Models;
using System;
using System.Web.Http;

namespace Brefi.WebApi.Controllers
{
    public class CatalogController : ApiController
    {
        private CatalogService catalogService;

        public CatalogController(CatalogService cService)
        {
            catalogService = cService;
        }
        
        public FullCatalog Get(DateTime? date = null)
        {
            return catalogService.GetLines(date);
        }

        [HttpPost]
        public FullCatalog Post([FromBody]FullCatalog json, [FromUri]DateTime? date = null)
        {
            return catalogService.UpdateLines(json, date);
        }   
    }
}