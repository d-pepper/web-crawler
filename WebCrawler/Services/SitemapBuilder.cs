using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Services
{
    public class SitemapBuilder
    {
        public async Task<List<Link>> BuildSitemap(string url)
        {
            var sitemap = await CrawlSitemap(url);

            return sitemap.OrderBy(l => l.Url).ToList();
        }

        private async Task<List<Link>> CrawlSitemap(string url, List<Link> linkList = null)
        {
            if (linkList == null)
            {
                linkList = new List<Link>();
            }

            var html = await GetHtmlStringAsync(url);

            if (!string.IsNullOrEmpty(html))
            {
                var htmlParser = new HtmlParser(); // Move to DI, Make singleton?
                var links = htmlParser.GetValidLinks(url, html).ToList();

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

                foreach (var link in linkList.ToList())
                {
                    if (!link.Crawled)
                    {
                        link.Crawled = true;
                        await CrawlSitemap(link.Url, linkList);
                    }
                }
            }

            return linkList;
        }

        private static async Task<string> GetHtmlStringAsync(string url)
        {
            var client = new HttpClient();

            try
            {
                var html = await client.GetStringAsync(url);
                return html;
            }
            catch(Exception)
            {
                return string.Empty;
            }
            
        }
    }
}
