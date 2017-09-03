using System;
namespace Api.Models.Domain.AppUser
{
    public class EditableAppUserViewModel
    {
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public EditableAppUserViewModel()
        {
        }
    }
}
