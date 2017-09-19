using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.AppUser
{
    public class EditableAppUserViewModel
    {
		[MaxLength(25), MinLength(1), Required]
		public string FirstName { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Id { get; set; }

		[MaxLength(25), MinLength(1), Required]
		public string LastName { get; set; }

		[Phone]
		public string PhoneNumber { get; set; }

        public EditableAppUserViewModel()
        {
        }
    }
}
