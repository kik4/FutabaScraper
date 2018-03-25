using System;
using System.Collections.Generic;
using AngleSharp;
using System.Threading.Tasks;
using System.Linq;

namespace FutabaScraper
{
    public class Scraper
    {
        public Scraper()
        {
        }

        public Board Board(string url, string name)
        {
            var splited = url.Split('/');
            return new Board(name, splited[2], splited[3]);
        }

        public async Task<List<Board>> Boards()
        {
            var address = "https://www.2chan.net/i.htm";
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(address);
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

        public async Task<List<Thread>> Threads()
        {
            var address = "https://may.2chan.net/27/futaba.php?mode=cat&sort=1";
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var table = document.QuerySelectorAll("table");
            var tds = table[1].QuerySelectorAll("a");
            var links = tds.Select(m => m.GetAttribute("href"));

            var result = new List<Thread>();
            foreach (var item in links)
            {
                var str = item.Split('/', '.')[1];
                int id;
                if (int.TryParse(str, out id))
                {
                    result.Add(new Thread(id));
                }
            }

            return result;
        }
    }
}
