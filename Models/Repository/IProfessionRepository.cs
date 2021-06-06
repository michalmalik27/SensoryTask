using System.Collections.Generic;

namespace SensoryTask.Models.Repository
{
    public interface IProfessionRepository
    {
        IEnumerable<Profession> GetAll();
        Profession Get(int id);
        void Add(Profession entity);
        void Update(Profession entity);
        void Delete(int id);
    }
}
