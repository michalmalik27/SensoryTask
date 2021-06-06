using Microsoft.EntityFrameworkCore;
using SensoryTask.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SensoryTask.Models.DataManager
{
    public class PersonManager : IPersonRepository
    {
        readonly SensoryTaskContext _context;

        public PersonManager(SensoryTaskContext context)
        {
            _context = context;
        }
        public IEnumerable<Person> GetAll()
        {
            return _context.Persons
                .Include(p => p.Profession)
                .ToList();
        }

        public Person Get(int id)
        {
            return _context.Persons
                .Include(p => p.Profession)
                .FirstOrDefault(c => c.IdNumber == id);
        }

        public void Add(Person entity)
        {
            _context.Persons.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Person entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
