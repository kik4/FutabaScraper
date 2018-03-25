using System.Text;

namespace FutabaScraper
{
    public class Board
    {
        public Board(string url)
        {
            var splited = url.Split('/');

            this.Name = "";
            this.Host = splited[2];
            this.FirstPath = splited[3];
        }

        internal Board(string name, string host, string firstPath)
        {
            this.Name = name;
            this.Host = host;
            this.FirstPath = firstPath;
        }

        public string Name { get; private set; }
        public string Host { get; private set; }
        public string FirstPath { get; private set; }

        internal string CatalogUrl(CatalogSort sort)
        {
            var sb = new StringBuilder();
            sb.Append("http://")
                .Append(this.Host)
                .Append("/")
                .Append(this.FirstPath)
                .Append("/futaba.php?mode=cat&sort=")
                .Append((int)sort);
            return sb.ToString();
        }
    }
}
