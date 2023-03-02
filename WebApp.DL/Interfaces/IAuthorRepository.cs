using WebApp.MODELS.Data;

namespace WebApp.DL.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();

        Author GetById(int id);

        void AddAuthor(Author author);

        void DeleteAuthor(int id);
    }
}
