using System.Text;

namespace FutabaScraper
{
    public class Thread
    {
        internal Thread(Board board, ulong no, ulong imageNo, string imageExtension)
        {
            this.Board = board;
            this.No = no;
            this.imageNo = imageNo;
            this.imageExtension = imageExtension;
        }

        public ulong No { get; private set; }
        public Board Board { get; private set; }
        private ulong imageNo { get; set; }
        private string imageExtension { get; set; }

        internal string ThreadUrl()
        {
            var sb = new StringBuilder();
            sb.Append("https://")
                .Append(this.Board.Host)
                .Append("/")
                .Append(this.Board.FirstPath)
                .Append("/res/")
                .Append(this.No)
                .Append(".htm");
            return sb.ToString();
        }

        public string CatalogImageUrl()
        {
            var sb = new StringBuilder();
            sb.Append("https://")
                .Append(this.Board.Host)
                .Append("/")
                .Append(this.Board.FirstPath)
                .Append("/cat/")
                .Append(this.imageNo)
                .Append("s.")
                .Append(this.imageExtension);
            return sb.ToString();
        }
    }
}
