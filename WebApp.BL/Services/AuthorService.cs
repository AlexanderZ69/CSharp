using WebApp.BL.Interfaces;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Data;

namespace WebApp.BL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void AddAuthor(Author author)
        {
            _authorRepository.AddAuthor(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }
    }
}

