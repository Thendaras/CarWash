using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Entities;

namespace CarWash.Repositories.Facility
{
    public class FacilityRepositoryMock : IFacilityRepository
    {
        public bool Create(Entities.Facility entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Entities.Facility entity)
        {
            throw new NotImplementedException();
        }

        public Entities.Facility Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entities.Facility> ReadAll()
        {
            return new List<Entities.Facility>()
            {
                new Entities.Facility
                {
                    ID = 0,
                    Location = "DKGRA01"
                },
                new Entities.Facility
                {
                    ID = 1,
                    Location = "SDNB"
                }
            };
        }

        public bool Update(Entities.Facility entity)
        {
            throw new NotImplementedException();
        }
    }
}
