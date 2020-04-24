using System.Collections.Generic;
using System.Linq;
using DynamoCode.Infrastructure.Data;
using MyApp.Domain;

namespace MyApp.Infrastructure
{
    public class PersonInMemoryRepository : IRepository<Person>
    {
        private readonly IList<Person> data = new List<Person>();
        public PersonInMemoryRepository()
        {
            data.Add(new Person { Id = 1, FirstName = "P1", LastName = "LN1", Age = 30 });
            data.Add(new Person { Id = 2, FirstName = "P2", LastName = "LN2", Age = 31 });
            data.Add(new Person { Id = 3, FirstName = "P3", LastName = "LN3", Age = 32 });
            data.Add(new Person { Id = 4, FirstName = "P4", LastName = "LN4", Age = 33 });
            data.Add(new Person { Id = 5, FirstName = "P5", LastName = "LN5", Age = 34 });
        }

        public IList<Person> All()
        {
            return data;
        }

        public IList<Person> All(int page, int itemsPerPage)
        {
            if (page <= 0)
                page = 1;

            var items = data;

            if (itemsPerPage > 0)
            {
                items = data.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            }
            return items;
        }

        public int Count()
        {
            return data.Count();
        }

        public Person FindBy(int id)
        {
            return data.First(x => x.Id == id);
        }

        public void Add(Person entity)
        {
            data.Add(entity);
        }

        public void Add(IEnumerable<Person> items)
        {
            foreach (var item in items)
            {
                data.Add(item);
            }
        }

        public void Delete(Person entity)
        {
            data.Remove(entity);
        }

        public void Delete(int id)
        {
            var item = FindBy(id);
            Delete(item);
        }

        public void Delete(IEnumerable<Person> entities)
        {
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public void Update(Person entity)
        {
            Delete(entity);
            Add(entity);
        }

    }
}
