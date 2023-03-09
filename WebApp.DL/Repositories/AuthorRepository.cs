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
            #pragma warning disable CS8603 // Possible null reference return.
            return DataStore.Authors
                .FirstOrDefault(author => author.Id == id);
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public void AddAuthor(Author author)
        {
            DataStore.Authors.Add(author);
        }

        public void DeleteAuthor(int id)
        {
            var author = GetById(id);
            if (author != null)
            {
                DataStore.Authors.Remove(author);
            }
        }
    }
}
