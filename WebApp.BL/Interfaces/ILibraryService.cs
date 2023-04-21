using WebApp.MODELS.Responses;

namespace WebApp.BL.Interfaces
{
    public interface ILibraryService
    {
        Task<GetAllBooksByAuthorResponse>
            GetAllBooksByAuthor(Guid authorId);
    }
}
