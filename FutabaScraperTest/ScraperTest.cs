using System;
using Xunit;
using FutabaScraper;


namespace FutabaScraperTest
{
    public class ScraperTest
    {
        [Fact]
        public async void ThreadsTest()
        {
            var scraper = new Scraper();
            var result = await scraper.Threads();

            Assert.True(result.Count > 0);
        }
    }
}
