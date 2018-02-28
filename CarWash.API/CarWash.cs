using CarWash.Entities;
using CarWash.Repositories;
using CarWash.Repositories.WashType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash
{
    public class CarWash
    {
        private WashTypeRepository _washTypeRepository;
        private ProcessRepository _processRepository;
        private FacilityRepository _facilityRepository;

        public CarWash(WashTypeRepository washTypeRepository, ProcessRepository processRepository, FacilityRepository facilityRepository)
        {
            _washTypeRepository = washTypeRepository;
            _processRepository = processRepository;
            _facilityRepository = facilityRepository;
        }

        public void StartCarWash(WashType washType)
        {

        }

        public void CreateDatabaseData()
        {
            _processRepository.Create(new Process { ID = 1, Name = "Iblødsætning", Cost = 9.95, Duration = 13, Priority = 1 });
            _processRepository.Create(new Process { ID = 2, Name = "Vask", Cost = 15.95, Duration = 10, Priority = 2 });
            _processRepository.Create(new Process { ID = 3, Name = "Undervognsvask", Cost = 13.95, Duration = 10, Priority = 3 });
            _processRepository.Create(new Process { ID = 4, Name = "Skyld", Cost = 7.95, Duration = 7, Priority = 4 });
            _processRepository.Create(new Process { ID = 5, Name = "Tørring", Cost = 7.95, Duration = 10, Priority = 5 });
            _processRepository.Create(new Process { ID = 6, Name = "Voksning", Cost = 27.95, Duration = 15, Priority = 6 });

            List<Process> standardProcesses = new List<Process>
            {
                _processRepository.Read(2),
                _processRepository.Read(4),
                _processRepository.Read(5)
            };

            _washTypeRepository.Create(new WashType
            {
                Name = "Standard Vask",
                Processes = new List<Process>
            {
                _processRepository.Read(2),
                _processRepository.Read(4),
                _processRepository.Read(5)
            }
            });
            _washTypeRepository.Create(new WashType
            {
                Name = "Vask PLUS",
                Processes = new List<Process>
            {
                _processRepository.Read(1),
                _processRepository.Read(2),
                _processRepository.Read(4),
                _processRepository.Read(5)
            }
            });
            _washTypeRepository.Create(new WashType
            {
                Name = "Guldvask",
                Processes = new List<Process>
            {
                _processRepository.Read(1),
                _processRepository.Read(2),
                _processRepository.Read(3),
                _processRepository.Read(4),
                _processRepository.Read(5)
            }
            });
            _washTypeRepository.Create(new WashType
            {
                Name = "Diamantvask Premium Plus Extreme",
                Processes = new List<Process>
            {
                _processRepository.Read(1),
                _processRepository.Read(2),
                _processRepository.Read(3),
                _processRepository.Read(4),
                _processRepository.Read(5),
                _processRepository.Read(6)
            }
            });

            _facilityRepository.Create(new Facility { Location = "Hal 1" });
            _facilityRepository.Create(new Facility { Location = "Hal 2" });
            _facilityRepository.Create(new Facility { Location = "Hal 3" });
        }
    }
}
