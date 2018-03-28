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
            // set up mock
            var doc = new HtmlParser().Parse(@"<!doctype html><html><head>< body >
<a href = ""//img.2chan.net/v.php?a&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">A</a><br>
<a href = ""//dec.2chan.net/v.php?b&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">B</a><br>
<a href = ""//jun.2chan.net/v.php?c&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">C</a><br>
<a href = ""//may.2chan.net/v.php?d&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">D</a><br>
<a href = ""//dat.2chan.net/v.php?e&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">E</a><br></body></html>");
            var mock = new Mock<IHttpClient>();
            mock.Setup(x => x.GetBoardsHtml()).ReturnsAsync(doc);

            // test result
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
            // setup mock
            var doc = new HtmlParser().Parse(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd""><html><head></head>
<body>
<table width='100%'><tr><th bgcolor='#0040e0'>
<font color='#FFFFFF'>カタログモード</font>
</th></tr></table>
<table border=1 align=center>
<tr>
<td><a href='res/283234.htm' target='_blank'><img src='/27/cat/1518058221204s.jpg' border=0 width=38 height=50 alt=""""></a><br><font size=2>3</font></td>
<td><a href='res/283253.htm' target='_blank'><small>画像なく</small></a><br><font size=2>12</font></td>
<td><a href='res/283260.htm' target='_blank'><img src='/27/cat/1518094159099s.jpg' border=0 width=30 height=50 alt=""""></a><br><font size=2>14</font></td>
</tr>
</table>
</body></html>");
            var mock = new Mock<IHttpClient>();
            mock.Setup(x => x.GetThreadsHtml(It.IsAny<Board>(), It.IsAny<CatalogSort>())).ReturnsAsync(doc);

            // test result
            var scraper = new Scraper(mock.Object);
            var board = new Board("https://may.2chan.net/27");
            var result = await scraper.Threads(board);
            Assert.Equal(result.Count, 3);
            Assert.Equal(result[0].Board, board);
            Assert.Equal<ulong>(result[0].No, 283234);
            Assert.Equal<ulong>(result[1].No, 283253);
            Assert.Equal<ulong>(result[2].No, 283260);
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
