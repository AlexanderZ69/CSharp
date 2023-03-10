using WebApp.DL.InMemoryDb;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Data;

namespace WebApp.DL.Repositories
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAll()
        {
            return DataStore.Books;
        }

        public Book GetById(int id)
        {
            return DataStore.Books
                .FirstOrDefault(x => x.Id == id);
        }

        public void Add(Book book)
        {
            DataStore.Books.Add(book);
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                DataStore.Books.Remove(book);
            }
        }
    }
}
