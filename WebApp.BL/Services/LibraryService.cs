using WebApp.BL.Interfaces;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Responses;

namespace WebApp.BL.Services
{
    internal class LibraryService : ILibraryService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;   

        public LibraryService(IAuthorRepository authorRepository, IBookRepository bookRepository) 
        { 
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public GetAllBooksByAuthorResponse GetAllBooksByAuthor(int authorId) 
        { 
            var response = new GetAllBooksByAuthorResponse(); 

            response.Author = _authorRepository.GetById(authorId);
            response.Books = _bookRepository.GetAll().Where(book => book.AuthorId == authorId);

            return response;
        }
    }
}
