using WebApp.MODELS.Data;

namespace WebApp.DL.InMemoryDb
{
    public static class DataStore
    {
        public static List<Author> Authors = new List<Author>()
        {
            new Author()
            {
                Id = 1,
                Name = "Alexander",
                Bio = "Some Bio ..."
            },
            new Author()
            {
                Id = 2,
                Name = "Anelia",
                Bio = "Some Bio ..."
            }
        };
    }
}
