using CarWash.Repositories.Process;
using CarWash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Repositories
{
    public class ProcessRepositoryMock : IProcessRepository
    {
        public bool Create(Entities.Process entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Entities.Process entity)
        {
            throw new NotImplementedException();
        }

        public Entities.Process Read(int id)
        {
            return new Entities.Process
            {
                Duration = 10000,
                Name = "Forvask"
            };
        }

        public List<Entities.Process> ReadAll()
        {
            return new List<Entities.Process>
            {
                new Entities.Process{Name = "Forvask", Duration = 10000},
                new Entities.Process{Name = "Skyldning", Duration = 2000}
            };
        }

        public bool Update(Entities.Process entity)
        {
            throw new NotImplementedException();
        }
    }
}
