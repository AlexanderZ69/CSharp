using WebApp.MODELS.Data;

namespace WebApp.DL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();

        Task<Author> GetById(Guid id);

        Task AddAuthor(Author author);

        Task DeleteAuthor(Guid id);
    }
}
