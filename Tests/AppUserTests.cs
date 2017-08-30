using System;
using Api.Models.Domain.AppUser;
using Xunit;

namespace Tests
{
    public class AppUserTests
    {
		[Fact]
		public void AppUserShouldHaveSpecificFields()
		{
			var user = new AppUser("Nicholas", "Barger", "nicholas@nicholasbarger.com");

			Assert.IsType<string>(user.FirstName);
			Assert.IsType<string>(user.LastName);
			Assert.IsType<string>(user.UserName);
		}

        [Fact]
        public void AppUserShouldHaveRequiredFields()
        {
            Assert.True(true);
        }
    }
}
