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

        [HttpGet("GetAllBooksByAuthor")]
        public async Task<IActionResult>
            GetAllBooksByAuthor(Guid authorId)
        {
            var result =
                await _libraryService.GetAllBooksByAuthor(authorId);

            if (result?.Author == null) return NotFound(authorId);

            return Ok(result);
        }
    }
}
