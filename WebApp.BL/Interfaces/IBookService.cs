using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

namespace WebApp.BL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();

        Book GetById(int id);

        void Add(AddBookRequest author);

        void Delete(int id);
    }
}
