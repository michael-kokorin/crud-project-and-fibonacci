using System;

namespace WebApplication1.Models.Requests
{
    public class UserUpdateRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
