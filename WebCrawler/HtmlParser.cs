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

            var htmlBody = htmlDoc.DocumentNode.SelectNodes("//body");

            var linkElements = htmlBody.Elements("a");

            var links = new List<string>();

            foreach (var node in linkElements)
            {
                if (node.NodeType == HtmlNodeType.Element)
                {
                    var href = node.Attributes.First(a => a.Name == "href");

                    var link = href.Value;

                    if (link.Contains(domain))
                    {
                        links.Add(href.Value);
                    }          
                }
            }           

            return links;
        }
    }
}
