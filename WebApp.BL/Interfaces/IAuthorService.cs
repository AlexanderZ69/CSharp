using WebApp.MODELS.Data;

namespace WebApp.BL.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll();

        Author GetById(int id);

        void AddAuthor(Author author);

        void DeleteAuthor(int id);
    }
}
