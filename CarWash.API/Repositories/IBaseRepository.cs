using System.Collections.Generic;

namespace CarWash.Repositories
{
    public interface IBaseRepository<Entity>
    {
        bool Create(Entity entity);
        Entity Read(int id);
        List<Entity> ReadAll();
        bool Update(Entity entity);
        bool Delete(Entity entity);
    }
}