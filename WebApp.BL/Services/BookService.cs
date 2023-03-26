using Microsoft.Extensions.Logging;
using WebApp.BL.Interfaces;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

namespace WebApp.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book? GetById(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book == null) 
            {
                _logger.LogError($"GetById:{id}");
            }
            return book;
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
