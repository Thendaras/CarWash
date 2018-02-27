using CarWash.API.Repositories.Process;
using CarWash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.API.Repositories
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
                Duration = 10000
            };
        }

        public List<Entities.Process> ReadAll()
        {
            return new List<Entities.Process>
            {
                new Entities.Process{Duration = 10000}
            };
        }

        public bool Update(Entities.Process entity)
        {
            throw new NotImplementedException();
        }
    }
}
