using AngleSharp.Parser.Html;
using FutabaScraper;
using Moq;
using Xunit;

namespace FutabaScraperTest
{
    public class ScraperTest
    {
        [Fact]
        public async void BoardsTest()
        {
            var boards = new HtmlParser().Parse(@"<!doctype html><html><head>< body >
<a href = ""//img.2chan.net/v.php?a&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">A</a><br>
<a href = ""//dec.2chan.net/v.php?b&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">B</a><br>
<a href = ""//jun.2chan.net/v.php?c&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">C</a><br>
<a href = ""//may.2chan.net/v.php?d&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">D</a><br>
<a href = ""//dat.2chan.net/v.php?e&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">E</a><br></body></html>");
            var mock = new Mock<IHttpClient>();
            mock.Setup(x => x.GetBoardsHtml()).ReturnsAsync(boards);

            var result = await new Scraper(mock.Object).Boards();
            Assert.Equal(result.Count, 5);
            Assert.Equal(result[0].Name, "A");
            Assert.Equal(result[0].Host, "img.2chan.net");
            Assert.Equal(result[0].FirstPath, "a");
            Assert.Equal(result[4].Host, "dat.2chan.net");
        }

        [Fact]
        public async void ThreadsTest()
        {
            var scraper = new Scraper();
            var result = await scraper.Threads(new Board("https://may.2chan.net/27"));

            Assert.True(result.Count > 50);
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
