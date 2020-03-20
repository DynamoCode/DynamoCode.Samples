using System;
using DynamoCode.Domain.Entities;

namespace MyApp.Domain
{
    public class Student : Entity<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Course { get; set; }
    }
}
