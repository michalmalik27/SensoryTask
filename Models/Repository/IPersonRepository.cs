using System.Collections.Generic;

namespace SensoryTask.Models.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        void Add(Person entity);
        void Update(Person entity);
        void Delete(int id);
    }
}
