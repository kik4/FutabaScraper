using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Services;
using FutabaScraper.Exceptions;
using System.Linq;
using System.Net;
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
            return await this.GetDocument(new Url("https://www.2chan.net/i.htm"));
        }

        public async Task<IDocument> GetThreadsHtml(Board board, CatalogSort sort)
        {
            // set cookie
            var config = this.context.Configuration;
            var cookieProvider = config.Services.OfType<ICookieProvider>().First();
            cookieProvider.SetCookie("https://" + board.Host, "cxyl=200x1x4");

            return await this.GetDocument(new Url(board.CatalogUrl(sort)));
        }

        public async Task<IDocument> GetPostsHtml(Thread thread)
        {
            return await this.GetDocument(new Url(thread.ThreadUrl()));
        }

        private async Task<IDocument> GetDocument(Url address)
        {
            var doc = await this.context.OpenAsync(address);
            if (doc.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpNotFoundException(doc?.GetElementsByTagName("h1").FirstOrDefault()?.FirstChild?.TextContent ?? "404 File Not Found");
            }
            else if((int)doc.StatusCode >= 400)
            {
                throw new HttpException(doc?.GetElementsByTagName("h1").FirstOrDefault()?.FirstChild?.TextContent ?? "Error");
            }
            return doc;
        }
    }
}
