using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
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
    }
}
