using CarWash.Entities;
using CarWash.Repositories.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Api
{
    public class FacilityControl
    {
        private IFacilityRepository _facilityRepository;
        public FacilityControl(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }
        public List<Facility> GetFacilities()
        {
            return _facilityRepository.ReadAll();
        }
    }
}
