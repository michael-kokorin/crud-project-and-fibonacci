using System;

namespace Business.Models
{
    public sealed class UserCreateDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
