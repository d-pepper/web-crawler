using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

            var builder = new SitemapBuilder();

            var client = new HttpClient();
            var html = await client.GetStringAsync(url);

            var sitemap = builder.BuildSitemap(url, html);

            return sitemap;
        }
    }
}
