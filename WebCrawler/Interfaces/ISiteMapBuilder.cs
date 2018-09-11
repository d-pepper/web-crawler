using System.Collections.Generic;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Interfaces
{
    public interface ISiteMapBuilder
    {
        Task<IEnumerable<Link>> BuildSiteMap(string url);
    }
}