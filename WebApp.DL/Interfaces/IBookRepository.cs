using WebApp.MODELS.Data;

namespace WebApp.DL.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<IEnumerable<Book>> GetAllByAuthorId(Guid authorId);
        Task <Book?> GetById(Guid id);
        Task Add(Book author);
        Task Delete(Guid id);
    }
}
