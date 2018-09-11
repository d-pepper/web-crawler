using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCrawler.Interfaces;
using WebCrawler.Models;

namespace WebCrawler.Services
{
    public class SiteMapBuilder : ISiteMapBuilder
    {
        private readonly IHtmlParser _htmlParser;
        private readonly IHtmlFetcher _htmlFetcher;

        public SiteMapBuilder(IHtmlParser htmlParser, IHtmlFetcher htmlFetcher)
        {
            _htmlParser = htmlParser;
            _htmlFetcher = htmlFetcher;
        }

        public async Task<IEnumerable<Link>> BuildSiteMap(string url)
        {
            var siteMap = await CrawlSiteMap(url);

            return siteMap.OrderBy(l => l.Url).ToList();
        }

        private async Task<List<Link>> CrawlSiteMap(string url, List<Link> linkList = null)
        {
            if (linkList == null)
            {
                linkList = new List<Link>();
            }

            var html = await _htmlFetcher.GetHtmlStringAsync(url);

            if (!string.IsNullOrEmpty(html))
            {
                var links = _htmlParser.GetValidLinks(url, html).ToList();

                AddNewLinks(linkList, links);

                foreach (var link in linkList.ToList())
                {
                    if (!link.Crawled)
                    {
                        link.Crawled = true;
                        await CrawlSiteMap(link.Url, linkList);
                    }
                }
            }

            return linkList;
        }

        private static void AddNewLinks(List<Link> linkList, List<string> links)
        {
            foreach (var link in links)
            {
                if (!linkList.Exists(l => l.Url == link))
                {
                    linkList.Add(new Link()
                    {
                        Url = link
                    });
                }
            }
        }
    }
}
