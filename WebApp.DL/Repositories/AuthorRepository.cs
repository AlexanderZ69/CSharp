using WebApp.DL.InMemoryDb;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Data;

namespace WebApp.DL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public IEnumerable<Author> GetAll()
        {
            return DataStore.Authors;
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
