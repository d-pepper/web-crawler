using System.Collections.Generic;

namespace WebCrawler.Interfaces
{
    public interface IHtmlParser
    {
        IEnumerable<string> GetValidLinks(string domain, string html);
    }
}