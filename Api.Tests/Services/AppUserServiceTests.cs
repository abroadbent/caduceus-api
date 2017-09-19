using System;
using AutoMapper;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Api.Models.System;
using Api.Models.Domain.AppUser;
using Api.Services.AppUserService;
using Api.Services;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

namespace Api.Tests
{
    public class AppUserServiceTests
    {
        private readonly IJwtService _jwtService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AppUserServiceTests()
        {
            _mapper = null;

            _jwtService = new JwtService();

            var factory = new LoggerFactory();
            _logger = factory.CreateLogger("AppUserServiceTests.Logger");
        }

		[Fact]
		public async Task AppUserCollectionShouldBeReturned()
		{
            var fakeUsers = new AppUser[] {
                new AppUser(),
                new AppUser()
            };

			var mockedDb = new Mock<ApplicationDbContext>();
            mockedDb.Setup(a => a.AppUsers).ReturnsDbSet(fakeUsers);

			var filter = new AppUserFilter();

			var service = new AppUserService(_mapper, mockedDb.Object, _jwtService, _logger);

			var collection = await service.Collection(filter);

			var expectedCount = 2;
			var actualCount = collection.Count;

			Assert.Equal(expectedCount, actualCount);
		}
    }
}
