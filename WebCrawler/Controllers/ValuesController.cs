using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCrawler.Services;

namespace WebCrawler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {
                
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var url = "https://hirespace.com/";

            var builder = new SitemapBuilder(); // Move to DI

            var client = new HttpClient();
            var html = await client.GetStringAsync(url);

            var sitemap = await builder.BuildSitemap(url);

            return sitemap.Select(l => l.Url);
        }
    }
}
