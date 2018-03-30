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
            return this.CommonUrl() + "/futaba.php?mode=cat&sort=" + (int)sort;
        }

        internal string CommonUrl()
        {
            return "https://" + this.Host + "/" + this.FirstPath;
        }
    }
}
