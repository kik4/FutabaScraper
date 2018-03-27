using AngleSharp;
using AngleSharp.Dom;
using System.Threading.Tasks;

namespace FutabaScraper
{
    public class HttpClient : IHttpClient
    {
        public async Task<IDocument> GetBoardsHtml()
        {
            var address = "https://www.2chan.net/i.htm";
            var config = Configuration.Default.WithDefaultLoader();
            return await BrowsingContext.New(config).OpenAsync(address);
        }
    }
}
