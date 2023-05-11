using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Moq;
using WebApp.BL.Interfaces;
using WebApp.BL.Services;
using WebApp.DL.Interfaces;
using WebApp.MODELS.Data;
using WebApplicationN.AutoMappings;

namespace BookStore.Test
{
    public class AuthorServiceTest
    {
        private readonly Mock<IAuthorRepository> _authorRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        private IList<Author> Authors = new List<Author>()
        {
            new Author()
            {
                Id = new Guid ("8f0a6217-1a54-435f-9f6e-2bfe6eee0f77"),
                Name = "Author 1",
                Bio = "Author 1 Bio"
            },

            new Author() 
            {
                Id = new Guid("2125cea2-1550-4175-994d-cb4f822cdad7"),
                Name = "Author 2",
                Bio = "Author 2 Bio"
            }
        };

        public AuthorServiceTest() 
        {
            var mockMapper = new MapperConfiguration(cfg=>
            {
                cfg.AddProfiles(new[] {new AutoMapperConfigs()});
            });

            _mapper = mockMapper.CreateMapper(); 

            _authorRepository = new Mock<IAuthorRepository>();

            _authorService = new AuthorService(_authorRepository.Object, _mapper);
        }

        [Fact]
        public async Task GetAll_Test_Ok()
        {
            //Setup
            var expectedCount = 2;

            _authorRepository.Setup(x => x.GetAll()).Returns(async () => Authors.AsEnumerable());

            //Inject

            //Act
            var result = await _authorService.GetAll();
            var enumerable = result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
            Assert.Equal(Authors, enumerable);
        }

        [Fact]
        public async Task GetById_Test_Ok()
        {
            //Setup
            var expectedId = Authors[0].Id;
            var expectedName = $"@{Authors[0].Name}";

            _authorRepository.Setup(x => x.GetById(expectedId))
                .Returns(async () => Authors.FirstOrDefault(a => a.Id == expectedId));

            //Inject

            //Act
            var result = await _authorService.GetById(expectedId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Name);
        }

        [Fact]
        public async Task GetById_Test_NotFound()
        {
            //Setup
            var authorId = Guid.NewGuid();

            _authorRepository.Setup(x => x.GetById(authorId))
                .Returns(async () => Authors.FirstOrDefault(a => a.Id == authorId));

            //Inject

            //Act
            var result = await _authorService.GetById(authorId);

            //Assert
            Assert.Null(result);
        }
    }
}
