using Microsoft.AspNetCore.Mvc;
using WebApp.BL.Interfaces;
using WebApp.MODELS.Data;

namespace WebApplicationNamespace.Controllers
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

        [HttpGet("GetAll")]
        public IEnumerable<Author> GetAll()
        {
            return _authorService.GetAll(); 
        }

        [HttpGet("GetbyId")]
        public Author GetById(int id)
        {
            return _authorService.GetById(id);
        }

        [HttpPost("Add")]
        public void Add([FromBody] Author author)
        {
            _authorService.AddAuthor(author);
        }

        [HttpDelete("Delete")]
        public void Delete(int authorId)
        {
            _authorService.DeleteAuthor(authorId);
        }
    }
}
