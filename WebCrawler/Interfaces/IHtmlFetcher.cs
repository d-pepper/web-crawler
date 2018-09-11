using System.Threading.Tasks;

namespace WebCrawler.Interfaces
{
    public interface IHtmlFetcher
    {
        Task<string> GetHtmlStringAsync(string url);
    }
}