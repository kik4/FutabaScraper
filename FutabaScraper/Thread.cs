namespace FutabaScraper
{
    public class Thread
    {
        public Thread(ulong ID)
        {
            this.ID = ID;
        }

        public ulong ID { get; private set; }
    }
}
