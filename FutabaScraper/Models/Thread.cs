using System.Text;

namespace FutabaScraper.Models
{
    public class Thread
    {
        internal Thread(Board board, ulong no, Image image)
        {
            this.Board = board;
            this.No = no;
            this.Image = image;
        }

        public ulong No { get; private set; }
        public Board Board { get; private set; }
        private Image Image { get; set; }

        internal string ThreadUrl()
        {
            var sb = new StringBuilder();
            sb.Append(this.Board.CommonUrl())
                .Append("/res/")
                .Append(this.No)
                .Append(".htm");
            return sb.ToString();
        }

        public string CatalogImageUrl()
        {
            if (this.Image == null) {
                return null;
            }

            var sb = new StringBuilder();
            sb.Append(this.Board.CommonUrl())
                .Append("/cat/")
                .Append(this.Image.No)
                .Append("s.")
                .Append(this.Image.Extension);
            return sb.ToString();
        }
    }
}
