using Microsoft.AspNetCore.Mvc;
using WebApp.BL.Interfaces;
using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

namespace WebApplicationN.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(IEnumerable<Author>))]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorService.GetAll());
        }

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(Author))]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        [ProducesResponseType(
            StatusCodes.Status404NotFound)]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //if (Guid.) return BadRequest(id);

            var result = await _authorService.GetById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddAuthorRequest author)
        {
            await _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid authorId)
        {
            await _authorService.DeleteAuthor(authorId);

            return Ok();
        }
    }
}
