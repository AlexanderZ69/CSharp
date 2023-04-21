using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Configs;
using WebApp.MODELS.Data;

namespace WebApp.DL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;
        private readonly IOptionsMonitor<MongoConfiguration> _config;

        public BookRepository(
            IOptionsMonitor<MongoConfiguration> config)
        {
            _config = config;
            var client =
                new MongoClient(_config.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(_config.CurrentValue.DatabaseName);

            _books =
                database.GetCollection<Book>($"{nameof(Book)}");
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _books.Find(book => true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAuthorId(Guid authorId)
        {
            return await _books
                .Find(a => a.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<Book?> GetById(Guid id)
        {
            return await _books
                .Find(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Add(Book author)
        {
            await _books.InsertOneAsync(author);
        }

        public async Task Delete(Guid id)
        {
            await _books
                .DeleteOneAsync(a => a.Id == id);
        }
    }
}
