using System;
using Xunit;
using FutabaScraper;


namespace FutabaScraperTest
{
    public class ScraperTest
    {
        private Scraper scraper = new Scraper();

        [Fact]
        public void BoardTest()
        {
            var board = scraper.Board("https://may.2chan.net/27", "‚Ë‚±");

            Assert.Equal(board.Host, "may.2chan.net");
            Assert.Equal(board.FirstPath, "27");
            Assert.Equal(board.Name, "‚Ë‚±");
        }

        [Fact]
        public async void BoardsTest()
        {
            var result = await scraper.Boards();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void ThreadsTest()
        {
            var result = await scraper.Threads();

            Assert.True(result.Count > 0);
        }
    }
}
