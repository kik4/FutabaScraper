using System.Text;

namespace FutabaScraper
{
    public class Thread
    {
        internal Thread(Board board, ulong no)
        {
            this.Board = board;
            this.No = no;
        }

        public ulong No { get; private set; }
        public Board Board { get; private set; }

        internal string ThreadUrl()
        {
            var sb = new StringBuilder();
            sb.Append("http://")
                .Append(this.Board.Host)
                .Append("/")
                .Append(this.Board.FirstPath)
                .Append("/res/")
                .Append(this.No)
                .Append(".htm");
            return sb.ToString();
        }
    }
}
