using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.BL.Interfaces;
using WebApp.MODELS.Responses;

namespace WebApplicationN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        GetAllBooksByAuthorResponse GetAllBooksByAuthor(int authorId)
        {
            return _libraryService.GetAllBooksByAuthor(authorId);
        }
    }
}
