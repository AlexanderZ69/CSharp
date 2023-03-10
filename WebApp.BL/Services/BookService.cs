using WebApp.BL.Interfaces;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

namespace WebApp.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void Add(AddBookRequest bookRequest)
        {
            var book = new Book()
            {
                Id = _bookRepository.GetAll()
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault().Id + 1,
                Description = bookRequest.Description,
                AuthorId = bookRequest.AuthorId,
                Name = bookRequest.Name
            };

            _bookRepository.Add(book);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
