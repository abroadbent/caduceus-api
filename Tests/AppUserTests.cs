using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models.Domain.AppUser;
using Api.Models.System;
using Api.Services;
using Moq;
using Xunit;

namespace Tests
{
    public class AppUserTests
    {
        private AppUser _testUser;
        private IAppUserService _service;

        public AppUserTests()
        {
            _testUser = new AppUser(1, "nicholas@nicholasbarger.com", "Nicholas", "Barger"); 

        }

		[Fact]
		public void AppUserShouldHaveSpecificFields()
		{
            var user = _testUser;

			Assert.IsType<string>(user.FirstName);
			Assert.IsType<string>(user.LastName);
			Assert.IsType<string>(user.UserName);
		}

        [Fact]
        public async Task AppUserCollectionShouldBeReturned()
        {
            var mockedDb = new Mock<ApplicationDbContext>();
            mockedDb.Setup(a => a.AppUsers.AddRange(new[] { new AppUser(), new AppUser() }));

            var filter = new AppUserFilter();

            _service = new AppUserService(null, mockedDb.Object, new JwtService());

            var collection = await _service.Collection(filter);

            var expectedCount = 2;
            var actualCount = collection.Count;

            Assert.Equal(expectedCount, actualCount);
		}
    }
}
