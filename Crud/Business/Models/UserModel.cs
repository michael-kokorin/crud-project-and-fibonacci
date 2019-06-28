using System;

namespace Business.Models
{
    public sealed class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime Created { get; set; }
    }
}
