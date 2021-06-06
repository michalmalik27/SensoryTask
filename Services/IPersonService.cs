using SensoryTask.Models;
using System.Collections.Generic;

namespace SensoryTask.Services
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetAll();
        public Person Get(int id);
        public void Add(Person entity);
        public void Update(Person entity);
        public void Delete(int id);
    }
}
