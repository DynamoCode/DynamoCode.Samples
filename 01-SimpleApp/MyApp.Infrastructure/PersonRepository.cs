using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamoCode.Infrastructure.Data;
using DynamoCode.Infrastructure.Data.Entities;
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
            data.Add(new Person { Id = 6, FirstName = "P6", LastName = "LN6", Age = 35 });
            data.Add(new Person { Id = 7, FirstName = "P7", LastName = "LN7", Age = 36 });
            data.Add(new Person { Id = 8, FirstName = "P8", LastName = "LN8", Age = 37 });
            data.Add(new Person { Id = 9, FirstName = "P9", LastName = "LN9", Age = 38 });
            data.Add(new Person { Id = 10, FirstName = "P10", LastName = "LN10", Age = 39 });
        }

        public IList<Person> All()
        {
            return data;
        }

        public PagedResult<Person> All(int page, int itemsPerPage)
        {
            if (page <= 0)
                page = 1;

            var items = data;

            if (itemsPerPage > 0)
            {
                items = data.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            }
            return new PagedResult<Person> { PageOfItems = items, TotalItems = data.Count };
        }
        public Person FindBy(int id)
        {
            return data.First(x => x.Id == id);
        }

        public Task<List<Person>> AllAsync()
        {
            return new Task<List<Person>>(() => All().ToList());
        }

        public Task<PagedResult<Person>> AllAsync(int page, int itemsPerPage)
        {
            return new Task<PagedResult<Person>>(() => All(page, itemsPerPage));
        }

        public Task<Person> FindByAsync(int id)
        {
            return new Task<Person>(() => FindBy(id));
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
