using WebApp.MODELS.Data;

namespace WebApp.DL.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();

        Book GetById(int id);

        void Add(Book author);

        void Delete(int id);
    }
}
