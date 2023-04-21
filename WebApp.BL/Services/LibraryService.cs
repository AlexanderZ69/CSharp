using WebApp.BL.Interfaces;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Responses;

namespace WebApp.BL.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public LibraryService(
            IAuthorRepository authorRepository,
            IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<GetAllBooksByAuthorResponse>
            GetAllBooksByAuthor(Guid authorId)
        {
            var response = new GetAllBooksByAuthorResponse();

            response.Author = await _authorRepository.GetById(authorId);
            response.Books = await _bookRepository.GetAllByAuthorId(authorId);

            return response;
        }
    }
}
