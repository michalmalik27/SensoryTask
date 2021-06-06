using SensoryTask.Models;
using SensoryTask.Models.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SensoryTask.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IProfessionRepository _professionRepository;

        public PersonService(IPersonRepository personRepository, IProfessionRepository professionRepository)
        {
            _personRepository = personRepository;
            _professionRepository = professionRepository;
        }

        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Person Get(int id)
        {
            return _personRepository.Get(id);
        }

        public void Add(Person person)
        {
            if (Get(person.IdNumber) != null)
                throw new Exception("Person already exists");

            if (!Validate(person, out ICollection<ValidationResult> results))
                throw new Exception(string.Join("\n", results.Select(o => o.ErrorMessage)));

            if (_professionRepository.Get(person.ProfessionId) == null)
                throw new Exception("Profession not exists");

            _personRepository.Add(person);
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
