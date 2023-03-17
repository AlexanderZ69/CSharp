using WebApp.MODELS.Data;

namespace WebApp.DL.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetAllByAuthorId(int authorId);
        Book GetById(int id);

        void Add(Book author);

        void Delete(int id);
    }
}
