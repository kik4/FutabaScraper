using System;

namespace FutabaScraper.Exceptions
{
    public class HttpNotFoundException : Exception
    {
        public HttpNotFoundException() { }

        public HttpNotFoundException(string message) : base(message) { }

        public HttpNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
