using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

namespace WebApp.BL.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(Guid id);
        Task Add(AddBookRequest author);
        Task Delete(Guid id);
    }
}
