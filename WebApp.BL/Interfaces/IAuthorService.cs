using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

namespace WebApp.BL.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author?> GetById(Guid id);
        Task AddAuthor(AddAuthorRequest author);
        Task DeleteAuthor(Guid id);
    }
}
