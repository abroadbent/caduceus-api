using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Api.Models.System;
using Api.Models.Domain.AppUser;
using Api.Services.AppUserService;
using Api.Services;

namespace Api.Tests
{
    public class AppUserServiceTests
    {
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

			var service = new AppUserService(null, mockedDb.Object, new JwtService());

			var collection = await service.Collection(filter);

			var expectedCount = 2;
			var actualCount = collection.Count;

			Assert.Equal(expectedCount, actualCount);
		}
    }
}
