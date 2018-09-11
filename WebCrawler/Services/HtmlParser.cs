using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using WebCrawler.Interfaces;

namespace WebCrawler.Services
{
    public class HtmlParser : IHtmlParser
    {
        public IEnumerable<string> GetValidLinks(string domain, string html)
        {            
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var linkElements = htmlDoc.DocumentNode.SelectNodes("//a[@href]");

            return linkElements
                .Select(linkElement => linkElement.Attributes["href"].Value)
                .Where(linkElement => linkElement.Contains(domain) || linkElement.StartsWith("/"))
                .ToList();
        }
    }
}