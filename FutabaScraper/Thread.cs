using System.Text;

namespace FutabaScraper
{
    public class Thread
    {
        internal Thread(Board Board, ulong ID)
        {
            this.Board = Board;
            this.ID = ID;
        }

        public ulong ID { get; private set; }
        public Board Board { get; private set; }

        internal string ThreadUrl()
        {
            var sb = new StringBuilder();
            sb.Append("http://")
                .Append(this.Board.Host)
                .Append("/")
                .Append(this.Board.FirstPath)
                .Append("/res/")
                .Append(this.ID)
                .Append(".htm");
            return sb.ToString();
        }
    }
}
