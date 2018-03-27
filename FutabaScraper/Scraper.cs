using AngleSharp;
using AngleSharp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace FutabaScraper
{
    public class Scraper
    {
        IHttpClient client;

        public Scraper(IHttpClient client = null)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (client == null)
            {
                this.client = new HttpClient();
            }
            else
            {
                this.client = client;
            }
        }

        public async Task<List<Board>> Boards()
        {
            var document = await client.GetBoardsHtml();
            var atags = document.QuerySelectorAll("a.itn");

            var result = new List<Board>();
            foreach (var item in atags)
            {
                var splited = item.GetAttribute("href").Split('/', '?', '&');
                var name = item.TextContent;
                result.Add(new Board(name, splited[2], splited[4]));
            }

            return result;
        }

        public async Task<List<Thread>> Threads(Board board, CatalogSort sort = CatalogSort.カタログ)
        {
            var address = board.CatalogUrl(sort);

            var config = Configuration.Default.WithDefaultLoader().WithCookies();
            var cookieProvider = config.Services.OfType<ICookieProvider>().First();
            cookieProvider.SetCookie("https://" + board.Host, "cxyl=200x1x4");
            var document = await BrowsingContext.New(config).OpenAsync(new Url(address));

            var table = document.QuerySelectorAll("table");
            var tds = table[1].QuerySelectorAll("a");
            var links = tds.Select(m => m.GetAttribute("href"));

            var result = new List<Thread>();
            foreach (var item in links)
            {
                var str = item.Split('/', '.')[1];
                ulong id;
                if (ulong.TryParse(str, out id))
                {
                    result.Add(new Thread(board, id));
                }
            }

            return result;
        }

        public async Task<List<Post>> Posts(Thread thread)
        {
            var address = thread.ThreadUrl();

            var config = Configuration.Default.WithDefaultLoader().WithCookies();
            var document = await BrowsingContext.New(config).OpenAsync(new Url(address));

            var result = new List<Post>();
            {
                var master = document.QuerySelector("div.thre");
                var image = master.QuerySelector("a").TextContent;
                var message = master.QuerySelector("blockquote").TextContent;
                var checkbox = master.QuerySelector("input");
                string title = null, name = null, ip = null, id = null;
                ulong no = 0;
                var next = checkbox.NextSibling;
                if (next.NodeName == "FONT")
                {
                    title = checkbox.NextSibling.TextContent;
                    next = next.NextSibling;
                }
                if (next.NodeValue.Contains("Name"))
                {
                    next = next.NextSibling;
                    name = next.LastChild.TextContent;
                    next = next.NextSibling;
                }
                var arr = next.TextContent.Trim('\n', ' ').Split(' ');
                var date = arr[0];
                for (var i = 1; i < arr.Length; i++)
                {
                    if (arr[i].Substring(0, 2) == "IP")
                    {
                        ip = arr[i].Substring(3);
                    }
                    else if (arr[i].Substring(0, 2) == "ID")
                    {
                        id = arr[i].Substring(3);
                    }
                    else if (arr[i].Substring(0, 2) == "No")
                    {
                        var str = arr[i].Substring(3);
                        no = ulong.Parse(str);
                    }
                }
                result.Add(new Post(no, date, message, image, title, name, id, ip));
            }

            var resList = document.QuerySelectorAll("table").Where(m => !string.IsNullOrEmpty(m.GetAttribute("border")));
            foreach (var item in resList)
            {
                var message = item.QuerySelector("blockquote").TextContent;
                string image = null;
                var aimage = item.QuerySelectorAll("a").Where(m => string.IsNullOrEmpty(m.GetAttribute("class")));
                if (aimage.Any())
                {
                    image = aimage.First().TextContent;
                }
                ////
                var checkbox = item.QuerySelector("input");
                string title = null, name = null, ip = null, id = null;
                ulong no = 0;
                var next = checkbox.NextSibling;
                if (next.NodeName == "FONT")
                {
                    title = checkbox.NextSibling.TextContent;
                    next = next.NextSibling;
                }
                if (next.NodeValue.Contains("Name"))
                {
                    next = next.NextSibling;
                    name = next.LastChild.TextContent;
                    next = next.NextSibling;
                }
                var arr = next.TextContent.Trim('\n', ' ').Split(' ');
                var date = arr[0];
                for (var i = 1; i < arr.Length; i++)
                {
                    if (arr[i].Substring(0, 2) == "IP")
                    {
                        ip = arr[i].Substring(3);
                    }
                    else if (arr[i].Substring(0, 2) == "ID")
                    {
                        id = arr[i].Substring(3);
                    }
                    else if (arr[i].Substring(0, 2) == "No")
                    {
                        var str = arr[i].Substring(3);
                        no = ulong.Parse(str);
                    }
                }
                ////
                result.Add(new Post(no, date, message, image, title, name, id, ip));
            }

            return result;
        }
    }
}
