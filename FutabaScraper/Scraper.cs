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

        public async Task<List<Thread>> Threads()
        {
            var address = "https://may.2chan.net/27/futaba.php?mode=cat";
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
