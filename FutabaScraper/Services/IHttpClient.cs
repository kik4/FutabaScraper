using AngleSharp.Dom;
using System.Threading.Tasks;

namespace FutabaScraper
{
    public interface IHttpClient
    {
        Task<IDocument> GetBoardsHtml();
        Task<IDocument> GetThreadsHtml(Board board, CatalogSort sort);
        Task<IDocument> GetPostsHtml(Thread thread);
    }
}
