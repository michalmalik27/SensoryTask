using Microsoft.EntityFrameworkCore;
using SensoryTask.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

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
                .FirstOrDefault(c => c.PersonId == id);
        }

        public void Add(Person entity)
        {
            _context.Persons.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Person entity)
        {
            var person = Get(entity.PersonId);

            person.IdNumber = entity.IdNumber;
            person.LastName = entity.LastName;
            person.FirstName = entity.FirstName;
            person.ProfessionId = entity.ProfessionId;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var person = Get(id);
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
