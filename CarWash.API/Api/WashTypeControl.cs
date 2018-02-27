using CarWash.API.Repositories;
using CarWash.API.Repositories.WashType;
using CarWash.Entities;
using CarWash.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.API.Api
{
    public class WashTypeControl
    {
        private IWashTypeRepository _washTypeRepository;
        public WashTypeControl(IWashTypeRepository washTypeRepository)
        {
            _washTypeRepository = washTypeRepository;
        }
        public List<WashType> GetWashTypes()
        {
            return _washTypeRepository.ReadAll();
        }
    }
}
