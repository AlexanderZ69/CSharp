using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

namespace WebApp.BL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll();

        Author? GetById(int id);

        void AddAuthor(AddAuthorRequest author);

        void DeleteAuthor(int id);
    }
}
