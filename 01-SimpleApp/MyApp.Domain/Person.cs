using DynamoCode.Domain.Entities;

namespace MyApp.Domain
{
    public class Person : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
