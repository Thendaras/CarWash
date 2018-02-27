using CarWash.Api;
using CarWash.API.Api;
using CarWash.API.Repositories;
using CarWash.API.Repositories.Process;
using CarWash.API.Repositories.WashType;
using CarWash.Repositories;
using CarWash.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarWash.Debug
{
    class Program
    {

        static void Main(string[] args)
        {
            Debug debug = new Debug();
            debug.Run().Wait();
            Console.WriteLine("Tasks completed");
        }


    }

    public class Debug
    {
        private IProcessRepository _processRepository;
        private IWashTypeRepository _washTypeRepository;

        private ProcessService _processService;

        private UserControl _userControl;
        private WashTypeControl _washTypeControl;
        
        public Debug()
        {
            _processRepository = new ProcessRepositoryMock();
            _washTypeRepository = new WashTypeRepositoryMock(_processRepository);

            _processService = new ProcessService(_processRepository);

            _userControl = new UserControl(_processService);
            _washTypeControl = new WashTypeControl(_washTypeRepository);
        }

        public async Task Run()
        {
            await _userControl.StartWash(_washTypeRepository.Read(1));
        }
    }
}
