using System.Text;

namespace FutabaScraper.Models
{
    public class Image
    {
        internal Image(Board board, ulong no, string extension)
        {
            this.Board = board;
            this.No = no;
            this.Extension = extension;
        }

        internal Image(Board board, string fileName)
        {
            this.Board = board;
            var splited = fileName.Split('.');
            this.No = ulong.Parse(splited[0]);
            this.Extension = splited[1];
        }

        internal Board Board { get; private set; }
        internal ulong No { get; set; }
        internal string Extension { get; set; }

        public string ThumbnailUrl()
        {
            var sb = new StringBuilder();
            sb.Append(this.Board.CommonUrl())
                .Append("/thumb/")
                .Append(this.No)
                .Append("s.")
                .Append(this.Extension);
            return sb.ToString();
        }

        public string Url()
        {
            var sb = new StringBuilder();
            sb.Append(this.Board.CommonUrl())
                .Append("/src/")
                .Append(this.No)
                .Append(".")
                .Append(this.Extension);
            return sb.ToString();
        }
    }
}
