using Microsoft.EntityFrameworkCore;
using SensoryTask.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SensoryTask.Models.DataManager
{
    public class ProfessionManager : IProfessionRepository
    {
        readonly SensoryTaskContext _context;

        public ProfessionManager(SensoryTaskContext context)
        {
            _context = context;
        }
        public IEnumerable<Profession> GetAll()
        {
            return _context.Professions
                .ToList();
        }

        public Profession Get(int id)
        {
            return _context.Professions
                .FirstOrDefault(c => c.ProfessionId == id);
        }

        public void Add(Profession entity)
        {
            _context.Professions.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Profession entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
