using WebApp.MODELS.Responses;

namespace WebApp.BL.Interfaces
{
    public interface ILibraryService
    {
        GetAllBooksByAuthorResponse 
            GetAllBooksByAuthor(int authorId);
    }
}
