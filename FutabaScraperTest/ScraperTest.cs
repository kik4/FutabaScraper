using System;
using Xunit;
using FutabaScraper;


namespace FutabaScraperTest
{
    public class ScraperTest
    {
        [Fact]
        public async void BoardTest()
        {
            var scraper = new Scraper();
            var result = await scraper.Boards();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void ThreadsTest()
        {
            var scraper = new Scraper();
            var result = await scraper.Threads();

            Assert.True(result.Count > 0);
        }
    }
}
