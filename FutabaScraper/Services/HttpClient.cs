using AngleSharp.Dom;
using FutabaScraper.Models;
using System.Threading.Tasks;

namespace FutabaScraper.Services
{
    public interface HttpClient
    {
        Task<IDocument> GetBoardsHtml();
        Task<IDocument> GetThreadsHtml(Board board, CatalogSort sort);
        Task<IDocument> GetPostsHtml(Thread thread);
    }
}
