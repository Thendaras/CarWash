using CarWash.Repositories;
using CarWash.Repositories.WashType;
using CarWash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Api
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
