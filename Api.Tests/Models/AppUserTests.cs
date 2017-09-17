using System;
using Api.Models.Domain.AppUser;
using Xunit;

namespace Api.Tests
{
    public class AppUserTests
    {
		private AppUser _testUser;

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
    }
}
