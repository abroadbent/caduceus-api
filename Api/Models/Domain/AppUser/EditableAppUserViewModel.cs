using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.AppUser
{
    public class EditableAppUserViewModel
    {
		[MaxLength(25), MinLength(1), Required]
		public string FirstName { get; set; }

		[MaxLength(25), MinLength(1), Required]
		public string LastName { get; set; }

		[Phone]
		public string PhoneNumber { get; set; }

        public EditableAppUserViewModel()
        {
        }
    }
}
