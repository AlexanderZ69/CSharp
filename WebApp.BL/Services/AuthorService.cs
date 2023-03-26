using AutoMapper;
using Microsoft.Extensions.Logging;
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
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorService> _logger;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper, ILogger<AuthorService> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author? GetById(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null)
            {
                _logger.LogError($"GetById:{id}");
            }
            return author;
        }

        public void AddAuthor(AddAuthorRequest authorRequest)
        {
            var author = _mapper.Map<Author>(authorRequest);
            {
                author.Id = _authorRepository.GetAll()
               .OrderByDescending(x => x.Id).First().Id + 1;

                _authorRepository.AddAuthor(author);
            };

            _authorRepository.AddAuthor(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }
    }
}

