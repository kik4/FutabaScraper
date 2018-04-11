using FutabaScraper.Models;
using Xunit;

namespace FutabaScraperTest
{
    public class BoardTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var board = new Board("https://may.2chan.net/27");

            Assert.Equal(board.Host, "may.2chan.net");
            Assert.Equal(board.FirstPath, "27");
        }
    }
}
