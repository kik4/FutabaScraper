using AngleSharp.Parser.Html;
using FutabaScraper;
using Moq;
using Xunit;

namespace FutabaScraperTest
{
    public class ScraperTest
    {
        IHttpClient mockClient;

        public ScraperTest()
        {
            // set up mock
            var boardsHtml = new HtmlParser().Parse(@"<!doctype html><html><head>< body >
<a href = ""//img.2chan.net/v.php?a&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">A</a><br>
<a href = ""//dec.2chan.net/v.php?b&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">B</a><br>
<a href = ""//jun.2chan.net/v.php?c&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">C</a><br>
<a href = ""//may.2chan.net/v.php?d&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">D</a><br>
<a href = ""//dat.2chan.net/v.php?e&guid=on"" data-role=""button"" class=""itn"" data-ajax=""false"">E</a><br></body></html>");
            var threadsHtml = new HtmlParser().Parse(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd""><html><head></head>
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
            var postsHtml = new HtmlParser().Parse(@"!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd""><html><head></head><body><div class=""thre"">画像ファイル名：<a href=""/27/src/1522040029588.jpg"" target=""_blank"">1522040029588.jpg</a>-(379459 B)<small>サムネ表示</small><br><a href=""/27/src/1522040029588.jpg"" target=""_blank""><img src=""/27/thumb/1522040029588s.jpg"" border=0 align=left width=251 height=167 hspace=20 alt=""379459 B""></a><input type=checkbox name=""284944"" value=delete id=delcheck284944><font color='#cc1105'><b>ちろ</b></font> 
Name <font color='#117743'><b>名有り </b></font> 18/03/26(月)13:53:49 IP:220.27.*(bbtec.net) No.284944 <a class=del href=""javascript:void(0);"" onclick=""del(284944);return(false);"">del</a>
<small>5月23日頃消えます</small>
<blockquote>ハイキーねこ</blockquote><table border=0><tr><td class=rts>…</td><td class=rtd>
<input type=checkbox name=""284945"" value=delete id=delcheck284945><font color='#cc1105'><b>ちろとめる</b></font> 
Name <font color='#117743'><b>名有り </b></font> 18/03/26(月)13:54:52 IP:220.27.*(bbtec.net) No.284945 <a class=del href=""javascript:void(0);"" onclick=""del(284945);return(false);"">del</a>
<br> &nbsp; &nbsp; <a href=""/27/src/1522040092289.jpg"" target=""_blank"">1522040092289.jpg</a>-(513782 B) <small>サムネ表示</small><br><a href=""/27/src/1522040092289.jpg"" target=""_blank""><img src=""/27/thumb/1522040092289s.jpg"" border=0 align=left width=251 height=167 hspace=20 alt=""513782 B""></a><blockquote style=""margin-left:291px;"">平和は長くは続かない。<br><br>め) お姉ちゃ～ん<br>ち) 弟～(?)</blockquote></td></tr></table>
<table border=0><tr><td class=rts>…</td><td class=rtd>
<input type=checkbox name=""284946"" value=delete id=delcheck284946><font color='#cc1105'><b>ちろとめる</b></font> 
Name <font color='#117743'><b>名有り </b></font> 18/03/26(月)13:55:30 IP:220.27.*(bbtec.net) No.284946 <a class=del href=""javascript:void(0);"" onclick=""del(284946);return(false);"">del</a>
<br> &nbsp; &nbsp; <a href=""/27/src/1522040130806.jpg"" target=""_blank"">1522040130806.jpg</a>-(449187 B) <small>サムネ表示</small><br><a href=""/27/src/1522040130806.jpg"" target=""_blank""><img src=""/27/thumb/1522040130806s.jpg"" border=0 align=left width=251 height=167 hspace=20 alt=""449187 B""></a><blockquote style=""margin-left:291px;"">め) もう終わり?<br>ち) 終わり。</blockquote></td></tr></table>
<table border=0><tr><td class=rts>…</td><td class=rtd>
<input type=checkbox name=""284947"" value=delete id=delcheck284947><font color='#cc1105'><b>める</b></font> 
Name <font color='#117743'><b>名有り </b></font> 18/03/26(月)13:55:54 IP:220.27.*(bbtec.net) No.284947 <a class=del href=""javascript:void(0);"" onclick=""del(284947);return(false);"">del</a>
<br> &nbsp; &nbsp; <a href=""/27/src/1522040154337.jpg"" target=""_blank"">1522040154337.jpg</a>-(360245 B) <small>サムネ表示</small><br><a href=""/27/src/1522040154337.jpg"" target=""_blank""><img src=""/27/thumb/1522040154337s.jpg"" border=0 align=left width=251 height=167 hspace=20 alt=""360245 B""></a><blockquote style=""margin-left:291px;"">今日もいっぱい遊んだ。</blockquote></td></tr></table>
<table border=0><tr><td class=rts>…</td><td class=rtd>
<input type=checkbox name=""284948"" value=delete id=delcheck284948><font color='#cc1105'><b>無題</b></font> 
Name <font color='#117743'><b>名無し </b></font> 18/03/26(月)15:57:42 IP:180.189.*(icnet.ne.jp) No.284948 <a class=del href=""javascript:void(0);"" onclick=""del(284948);return(false);"">del</a>
<blockquote>ちろお嬢様、お美しい&#10024;&#10024;&#10024;<br>める嬢は相変わらず可笑し可愛い</blockquote></td></tr></table>
<table border=0><tr><td class=rts>…</td><td class=rtd>
<input type=checkbox name=""284949"" value=delete id=delcheck284949><font color='#cc1105'><b>無題</b></font> 
Name <font color='#117743'><b>名無し </b></font> 18/03/26(月)19:39:36 IP:218.218.*(odn.ad.jp) No.284949 <a class=del href=""javascript:void(0);"" onclick=""del(284949);return(false);"">del</a>
<blockquote>めるの黒い部分はチビ黒に似てるような気がする</blockquote></td></tr></table>
<table border=0><tr><td class=rts>…</td><td class=rtd>
<input type=checkbox name=""284960"" value=delete id=delcheck284960><font color='#cc1105'><b>無題</b></font> 
Name <font color='#117743'><b>名無し </b></font> 18/03/27(火)14:19:55 IP:2405:6580.*(ipv6) No.284960 <a class=del href=""javascript:void(0);"" onclick=""del(284960);return(false);"">del</a>
<blockquote><font color=""#789922"">&gt;今日もいっぱい遊んだ。</font><br>意外と淡泊</blockquote></td></tr></table>
<table border=0><tr><td class=rts>…</td><td class=rtd>
<input type=checkbox name=""284963"" value=delete id=delcheck284963><font color='#cc1105'><b>無題</b></font> 
Name <font color='#117743'><b>名無し </b></font> 18/03/27(火)20:10:28 IP:153.151.*(dti.ne.jp) No.284963 <a class=del href=""javascript:void(0);"" onclick=""del(284963);return(false);"">del</a>
<blockquote>絶対行間で暴れてる</blockquote></td></tr></table>
<div style=""clear:left""></div>
</div><!--スレッド終了-->
</body>
</html>
");
            var mock = new Mock<IHttpClient>();
            mock.Setup(x => x.GetBoardsHtml()).ReturnsAsync(boardsHtml);
            mock.Setup(x => x.GetThreadsHtml(It.IsAny<Board>(), It.IsAny<CatalogSort>())).ReturnsAsync(threadsHtml);
            mock.Setup(x => x.GetPostsHtml(It.IsAny<Thread>())).ReturnsAsync(postsHtml);

            this.mockClient = mock.Object;
        }

        [Fact]
        public async void BoardsTest()
        {
            var result = await new Scraper(this.mockClient).Boards();
            Assert.Equal(result.Count, 5);
            Assert.Equal(result[0].Name, "A");
            Assert.Equal(result[0].Host, "img.2chan.net");
            Assert.Equal(result[0].FirstPath, "a");
            Assert.Equal(result[4].Host, "dat.2chan.net");
        }

        [Fact]
        public async void ThreadsTest()
        {
            var scraper = new Scraper(this.mockClient);
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
            var scraper = new Scraper(this.mockClient);
            var threads = await scraper.Threads(new Board("https://may.2chan.net/27"));
            var result = await scraper.Posts(threads[0]);
            Assert.Equal(result.Count, 8);
        }
    }
}
