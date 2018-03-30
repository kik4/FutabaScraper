using System;
namespace FutabaScraper
{
    public class Image
    {
        internal Image(ulong no, string extension)
        {
            this.No = no;
            this.Extension = extension;
        }

        internal ulong No { get; set; }
        internal string Extension { get; set; }
    }
}
