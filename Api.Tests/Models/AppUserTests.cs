using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        [Fact]
        public void AppUserConstructorSetsDefaults()
        {
            var user = new AppUser();

            Assert.True(user.IsActive);
            Assert.NotNull(user.Created);
        }

        [Fact]
        public void AppUserValidatesTenant()
        {
            var user = _testUser;
            user.TenantId = 0;  // bad

            var results = new List<ValidationResult>();
            Validator.TryValidateObject(user, new ValidationContext(user), results, true);

            Assert.True(results.Any(result => result.ErrorMessage == "The field TenantId must be between 1 and 2147483647."));
        }

        [Fact]
        public void AppUserValidatesFirstAndLastName()
        {
            var user = _testUser;
            user.FirstName = string.Empty;
            user.LastName = string.Empty;

            var results = new List<ValidationResult>();
            Validator.TryValidateObject(user, new ValidationContext(user), results, true);

            Assert.True(results.Any(result => result.ErrorMessage == "The FirstName field is required."));
            Assert.True(results.Any(result => result.ErrorMessage == "The LastName field is required."));
        }

        [Fact]
        public void AppUserValidatesFirstAndLastNameLength()
        {
            var user = _testUser;
            user.FirstName = "I am a ridiculously long first name that makes no real sense at all.";
            user.LastName = "This is my equally crazy long last name which also makes no real sense.";

			var results = new List<ValidationResult>();
			Validator.TryValidateObject(user, new ValidationContext(user), results, true);

			Assert.True(results.Any(result => result.ErrorMessage == "The field FirstName must be a string or array type with a maximum length of '25'."));
			Assert.True(results.Any(result => result.ErrorMessage == "The field LastName must be a string or array type with a maximum length of '25'."));
        }
    }
}
