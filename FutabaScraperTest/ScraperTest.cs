using FutabaScraper;
using Xunit;

namespace FutabaScraperTest
{
    public class ScraperTest
    {
        private Scraper scraper = new Scraper();

        [Fact]
        public void BoardTest()
        {
            var board = new Board("https://may.2chan.net/27");

            Assert.Equal(board.Host, "may.2chan.net");
            Assert.Equal(board.FirstPath, "27");
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
            var result = await scraper.Threads(new Board("https://may.2chan.net/27"));

            Assert.True(result.Count > 50);
        }

        [Fact]
        public async void PostsTest()
        {
            var threads = await scraper.Threads(new Board("https://may.2chan.net/27"));
            var result = await scraper.Posts(threads[0]);

            Assert.True(result.Count > 0);
        }
    }
}
