﻿using WebApp.DL.Interfaces;
using WebApp.MODELS.Configs;
using WebApp.MODELS.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApp.DL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMongoCollection<Author> _authors;
        private readonly IOptionsMonitor<MongoConfiguration> _config;

        public AuthorRepository(
            IOptionsMonitor<MongoConfiguration> config)
        {
            _config = config;
            var client =
                new MongoClient(_config.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(_config.CurrentValue.DatabaseName);

            _authors =
                database.GetCollection<Author>($"{nameof(Author)}");
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authors.Find(author => true)
                .ToListAsync();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _authors
                .Find(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task AddAuthor(Author author)
        {
            await _authors.InsertOneAsync(author);
        }

        public async Task DeleteAuthor(Guid id)
        {
            await _authors
                .DeleteOneAsync(a => a.Id == id);
        }
    }
}
