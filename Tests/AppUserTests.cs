using System;
using Api.Models.Domain.AppUser;
using Xunit;

namespace Tests
{
    public class AppUserTests
    {
        private AppUser _testUser;

        public AppUserTests()
        {
            _testUser = new AppUser("Nicholas", "Barger", "nicholas@nicholasbarger.com");    
        }

		[Fact]
		public void AppUserShouldHaveSpecificFields()
		{
            var user = _testUser;

			Assert.IsType<string>(user.FirstName);
			Assert.IsType<string>(user.LastName);
			Assert.IsType<string>(user.UserName);
		}
    }
}
