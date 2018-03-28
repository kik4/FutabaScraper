using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Services;
using System.Linq;
using System.Threading.Tasks;

namespace FutabaScraper
{
    public class HttpClient : IHttpClient
    {
        IBrowsingContext context;

        public HttpClient()
        {
            var config = Configuration.Default.WithDefaultLoader().WithCookies();
            this.context = BrowsingContext.New(config);
        }

        public async Task<IDocument> GetBoardsHtml()
        {
            var address = "https://www.2chan.net/i.htm";
            return await this.context.OpenAsync(address);
        }

        public async Task<IDocument> GetThreadsHtml(Board board, CatalogSort sort)
        {
            // set cookie
            var config = this.context.Configuration;
            var cookieProvider = config.Services.OfType<ICookieProvider>().First();
            cookieProvider.SetCookie("https://" + board.Host, "cxyl=200x1x4");

			var address = board.CatalogUrl(sort);
            return await this.context.OpenAsync(new Url(address));
        }

        public async Task<IDocument> GetPostsHtml(Thread thread)
        {
            var address = thread.ThreadUrl();
            return await this.context.OpenAsync(new Url(address));
        }
    }
}
