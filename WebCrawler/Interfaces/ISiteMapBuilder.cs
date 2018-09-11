using System.Collections.Generic;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Interfaces
{
    public interface ISiteMapBuilder
    {
        Task<List<Link>> BuildSiteMap(string url);
    }
}