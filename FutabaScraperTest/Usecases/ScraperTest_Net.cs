using FutabaScraper;
using FutabaScraper.Exceptions;
using Xunit;

namespace FutabaScraperTest
{
    public class ScraperTest_Net
    {
        [Fact]
        public async void BoardsTest()
        {
            var result = await new Scraper().Boards();
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void ThreadsTest()
        {
            var scraper = new Scraper();
            var board = new Board("https://may.2chan.net/27");
            var result = await scraper.Threads(board);
            Assert.True(result.Count > 50);

            await Assert.ThrowsAsync<HttpNotFoundException>(async () =>
            {
                await scraper.Threads(new Board("https://may.2chan.net/270"));
            });
        }

        [Fact]
        public async void PostsTest()
        {
            var scraper = new Scraper();
            var threads = await scraper.Threads(new Board("https://may.2chan.net/27"));
            var result = await scraper.Posts(threads[0]);
            Assert.True(result.Count > 0);
        }
    }
}
