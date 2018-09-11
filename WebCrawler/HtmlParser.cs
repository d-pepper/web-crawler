using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebCrawler
{
    public class HtmlParser
    {
        public IEnumerable<string> GetValidLinks(string domain, string html)
        {            
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var linkElements = htmlDoc.DocumentNode.SelectNodes("//a[@href]");

            return linkElements
                .Select(linkElement => linkElement.Attributes["href"].Value)
                .Where(linkElement => linkElement.Contains(domain))
                .ToList();
        }
    }
}
