using System;

namespace FutabaScraper
{
    public class Post
    {
        public Post(ulong no, string date, string message, string imageFileName = null, string title = null, string name = null, string id = null, string ip = null)
        {
            this.No = no;
            this.Date = date;
            this.Message = message;
            this.ImageFileName = imageFileName;
            this.Title = title;
            this.Name = name;
            this.ID = id;
            this.IP = ip;
        }

        public ulong No { get; private set; }
        public string Date { get; private set; }
        public string Message { get; private set; }
        public string ImageFileName { get; private set; }
        public string Title { get; private set; }
        public string Name { get; private set; }
        public string ID { get; private set; }
        public string IP { get; private set; }
    }
}
