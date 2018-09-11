using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebCrawler.Interfaces;

namespace WebCrawler.Services
{
    public class HtmlFetcher : IHtmlFetcher
    {
        public async Task<string> GetHtmlStringAsync(string url)
        {
            var client = new HttpClient();

            try
            {
                var html = await client.GetStringAsync(url);
                return html;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}