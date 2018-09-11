using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrawler
{
    public class SitemapBuilder
    {
        public IEnumerable<string> BuildSitemap(string domain, string html)
        {
            var sitemap = new List<string>();

            var htmlParser = new HtmlParser();
            var initialLinks = htmlParser.GetValidLinks(domain, html);

            return sitemap.Union(initialLinks).ToList();
        }

    }
}
