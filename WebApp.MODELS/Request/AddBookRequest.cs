namespace WebApp.MODELS.Request
{
    public class AddBookRequest
    {
        public string Name { get; set; }

        public int AuthorId { get; set; }

        public string Description { get; set; }
    }
}
