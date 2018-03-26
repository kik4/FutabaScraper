using System;

namespace FutabaScraper
{
    public class Post
    {
        public Post(ulong No, string Date, string Message, string ImageFileName = null, string Title = null, string Name = null, string ID = null, string IP = null)
        {
            this.No = No;
            this.Date = Date;
            this.Message = Message;
            this.ImageFileName = ImageFileName;
            this.Title = Title;
            this.Name = Name;
            this.ID = ID;
            this.IP = IP;
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
