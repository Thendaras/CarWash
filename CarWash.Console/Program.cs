using CarWash.Repositories;
using CarWash.Repositories.WashType;

namespace CarWash.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            FacilityRepository facilityRepository = new FacilityRepository();
            ProcessRepository processRepository = new ProcessRepository();
            WashTypeRepository washTypeRepository = new WashTypeRepository();

            CarWash carWash = new CarWash(washTypeRepository, processRepository, facilityRepository);

            carWash.CreateDatabaseData();

            //Debug debug = new Debug();
            //debug.Run().Wait();
            System.Console.WriteLine("Completed!");
        }
    }
}