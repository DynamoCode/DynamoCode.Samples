using DynamoCode.Domain.Entities;

namespace MyApp.Domain
{
    public class Product : IEntityKey<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}