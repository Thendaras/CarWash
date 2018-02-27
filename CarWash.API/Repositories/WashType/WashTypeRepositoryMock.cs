using CarWash.API.Repositories.Process;
using CarWash.Entities;
using CarWash.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.API.Repositories.WashType
{
    public class WashTypeRepositoryMock : IWashTypeRepository
    {
        private IProcessRepository _processRepositoryMock;
        public WashTypeRepositoryMock(IProcessRepository processRepositoryMock)
        {
            _processRepositoryMock = processRepositoryMock;
        }

        public bool Create(Entities.WashType entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Entities.WashType entity)
        {
            throw new NotImplementedException();
        }

        public Entities.WashType Read(int id)
        {
            return new Entities.WashType()
            {
                ID = 1,
                Name = "Bronze",
                Processes = _processRepositoryMock.ReadAll()
            };
        }

        public List<Entities.WashType> ReadAll()
        {
            return new List<Entities.WashType>
            {
                new Entities.WashType()
                {
                    ID = 1,
                    Name = "Bronze",
                    Processes = _processRepositoryMock.ReadAll()
                }
            };
        }

        public bool Update(Entities.WashType entity)
        {
            throw new NotImplementedException();
        }
    }
}
