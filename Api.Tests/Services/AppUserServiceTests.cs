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

		[Fact]
        public async Task AppUserCollectionShouldReturnActiveOnlyByDefault()
		{
			var fakeUsers = new AppUser[] {
                new AppUser() { IsActive = true },
                new AppUser() { IsActive = true },
                new AppUser() { IsActive = false }
			};

			var mockedDb = new Mock<ApplicationDbContext>();
			mockedDb.Setup(a => a.AppUsers).ReturnsDbSet(fakeUsers);

			var filter = new AppUserFilter();  // defaults to IsActive = true

			var service = new AppUserService(_mapper, mockedDb.Object, _jwtService, _logger);

			var collection = await service.Collection(filter);

			var expectedCount = 2;
			var actualCount = collection.Count;

			Assert.Equal(expectedCount, actualCount);
		}

        [Fact]
        public async Task AppUserCollectionShouldReturnInactiveRecordsIfSpecified()
        {
			var fakeUsers = new AppUser[] {
				new AppUser() { IsActive = true },
				new AppUser() { IsActive = true },
				new AppUser() { IsActive = false }
			};

			var mockedDb = new Mock<ApplicationDbContext>();
			mockedDb.Setup(a => a.AppUsers).ReturnsDbSet(fakeUsers);

            var filter = new AppUserFilter();
            filter.IsActive = false;

			var service = new AppUserService(_mapper, mockedDb.Object, _jwtService, _logger);

			var collection = await service.Collection(filter);

			var expectedCount = 1;
			var actualCount = collection.Count;

			Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public async Task CreateValidAppUser()
        {
            var registrationVm = new RegistrationViewModel("Nicholas", "Barger", "nicholas@nicholasbarger.com", "Passw0rd!");
            registrationVm.PhoneNumber = "239-216-3766";

            var mockedDb = new Mock<ApplicationDbContext>();

            var service = new AppUserService(_mapper, mockedDb.Object, _jwtService, _logger);

            var user = await service.Create(registrationVm);

            Assert.True(user.Id > 0);
        }

        [Fact]
        public async Task DisableAppUser()
        {
            int id = 1;

			var fakeUsers = new AppUser[] {
                new AppUser() { Id = 1 },
                new AppUser() { Id = 2 }
			};

			var mockedDb = new Mock<ApplicationDbContext>();
			mockedDb.Setup(a => a.AppUsers).ReturnsDbSet(fakeUsers);

            var service = new AppUserService(_mapper, mockedDb.Object, _jwtService, _logger);

            var result = await service.Disable(id);

            Assert.True(result);
        }
    }
}
