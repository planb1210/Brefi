using Brefi.Services;
using Brefi.Services.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

        [HttpGet]
        public FullCatalog Get(DateTime? date = null)
        {
            return catalogService.GetLines(date);
        }

        [HttpGet]
        public HttpResponseMessage GetDBFile(string id)
        {
            var fileContent = catalogService.GetDBFile();
            byte[] bytes = Encoding.ASCII.GetBytes(fileContent);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(bytes);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "fileName.csv";

            return response;
        }

        [HttpPost]
        public FullCatalog UpdateLines([FromBody]FullCatalog fullCatalog, [FromUri]DateTime? date = null)
        {
            return catalogService.UpdateLines(fullCatalog, date);
        }

        [HttpPost]
        public async Task<string> Upload()
        {
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            var fileNameParam = provider.Contents[0].Headers.ContentDisposition.Parameters.FirstOrDefault(p => p.Name.ToLower() == "filename");
            string fileName = (fileNameParam == null) ? "" : fileNameParam.Value.Trim('"');
            byte[] file = await provider.Contents[0].ReadAsByteArrayAsync();
            var str = file.ToString();

            var result = string.Format("Received '{0}' with length: {1}", fileName, file.Length);
            return result;
        }
    }
}