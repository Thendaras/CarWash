using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.API.Repositories
{
    public interface IBaseRepository<Entity>
    {
        bool Create();
        Entity Read(int id);
        List<Entity> ReadAll();
        bool Update(Entity entity);
        bool Delete(Entity entity);
    }
}
