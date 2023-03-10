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

        public static List<Book> Books = new List<Book>()
           {
                new Book()
                {
                    Id = 1,
                    Name = "C# Programming",
                    Description = "Some description ..."
                },
                new Book()
                {
                    Id = 2,
                    Name = "Python Programming",
                    Description = "Some description ..."
                }
           };
    }
}
