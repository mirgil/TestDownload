using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using TestDownload.Src;

namespace TestDownload.Controllers
{
    public class DownloadController : ApiController
    {
        public HttpResponseMessage Get(long size, int delay = -1)
        {
            Stream st = new StreamSimulator(size, delay);
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(st)
            };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "file.tmp" };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

    }
}