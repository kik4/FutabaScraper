using System;
namespace FutabaScraper
{
    public class Board
    {
        public Board(string name, string host, string firstPath)
        {
            this.Name = name;
            this.Host = host;
            this.FirstPath = firstPath;
        }

        public string Name { get; private set; }
        public string Host { get; private set; }
        public string FirstPath { get; private set; }
    }
}
