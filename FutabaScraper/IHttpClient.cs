using AngleSharp.Dom;
using System.Threading.Tasks;

namespace FutabaScraper
{
    public interface IHttpClient
    {
        Task<IDocument> GetBoardsHtml();
    }
}
