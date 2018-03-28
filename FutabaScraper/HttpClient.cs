using AngleSharp;
using AngleSharp.Services;
using System.Linq;
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

        public async Task<IDocument> GetThreadsHtml(Board board, CatalogSort sort)
        {
            var address = board.CatalogUrl(sort);
            var config = Configuration.Default.WithDefaultLoader().WithCookies();
            var cookieProvider = config.Services.OfType<ICookieProvider>().First();
            cookieProvider.SetCookie("https://" + board.Host, "cxyl=200x1x4");
            return await BrowsingContext.New(config).OpenAsync(new Url(address));
        }
    }
}
