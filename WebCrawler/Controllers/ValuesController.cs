using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebCrawler.Interfaces;

namespace WebCrawler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISiteMapBuilder _siteMapBuilder;

        public ValuesController(ISiteMapBuilder siteMapBuilder)
        {
            _siteMapBuilder = siteMapBuilder;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            const string url = "https://hirespace.com/"; // Pass this in to method, i.e with POST

            var siteMap = await _siteMapBuilder.BuildSiteMap(url);

            return siteMap.Select(l => l.Url);
        }
    }
}