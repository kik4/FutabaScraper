namespace FutabaScraper.Models
{
    public class Post
    {
        public Post(ulong no, string date, string message, Image image = null, string title = null, string name = null, string id = null, string ip = null)
        {
            this.No = no;
            this.Date = date;
            this.Message = message;
            this.Image = image;
            this.Title = title;
            this.Name = name;
            this.ID = id;
            this.IP = ip;
        }

        public ulong No { get; private set; }
        public string Date { get; private set; }
        public string Message { get; private set; }
        public Image Image { get; private set; }
        public string Title { get; private set; }
        public string Name { get; private set; }
        public string ID { get; private set; }
        public string IP { get; private set; }
    }
}
