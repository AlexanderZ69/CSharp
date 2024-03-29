﻿using AutoMapper;
using WebApp.BL.Interfaces;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

namespace WebApp.BL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<Author?> GetById(Guid id)
        {
            // return await _authorRepository.GetById(id);
            var result = await _authorRepository.GetById(id);
            if (result == null) return null;
            result.Name = $"@{result.Name}";

            return result;
        }

        public async Task AddAuthor(AddAuthorRequest authorRequest)
        {
            var author = _mapper.Map<Author>(authorRequest);

            author.Id = Guid.NewGuid();

            await _authorRepository.AddAuthor(author);
        }

        public async Task DeleteAuthor(Guid id)
        {
            await _authorRepository.DeleteAuthor(id);
        }
    }
}

