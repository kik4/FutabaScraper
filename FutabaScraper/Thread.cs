using System;
namespace FutabaScraper
{
    public class Thread
    {
        public Thread(int ID)
        {
            this.ID = ID;
        }

        public int ID { get; private set; }
    }
}
