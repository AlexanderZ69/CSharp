using WebApp.BL.Interfaces;
using WebApp.DL.Interfaces;
using WebApp.DL.Repositories;
using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

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

        public void AddAuthor(AddAuthorRequest authorRequest)
        {
            var author = new Author()
            {
                Id = _authorRepository.GetAll()
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault().Id + 1,
                Bio = authorRequest.Bio,
                Name = authorRequest.Name
            };

            _authorRepository.AddAuthor(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }
    }
}

