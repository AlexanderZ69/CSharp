using WebApp.MODELS.Data;

namespace WebApp.MODELS.Responses
{
    public class GetAllBooksByAuthorResponse
    {
        public Author Author { get; set;}
        public IEnumerable<Book> Books { get; set; }

    }
}
