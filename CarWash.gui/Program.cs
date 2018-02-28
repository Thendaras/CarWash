using CarWash.Api;
using CarWash.Entities;
using CarWash.Repositories;
using CarWash.Repositories.Facility;
using CarWash.Repositories.Order;
using CarWash.Repositories.Process;
using CarWash.Repositories.WashType;
using CarWash.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarWash.gui
{
    class Program
    { 
        static void Main(string[] args)
        {
            // Repo Init
            IFacilityRepository facilityRepository = new FacilityRepositoryMock();
            IProcessRepository processRepository = new ProcessRepositoryMock();
            IWashTypeRepository washTypeRepository = new WashTypeRepositoryMock(processRepository);
            IOrderRepository orderRepository = new OrderRepository();

            // Service Init
            ProcessService processService = new ProcessService(processRepository);

            // Control Init
            FacilityControl facilityControl = new FacilityControl(facilityRepository);
            WashTypeControl washTypeControl = new WashTypeControl(washTypeRepository);
            WashControl washControl = new WashControl(processService, orderRepository);

            // UI Init
            while (true)
            {
                MainMenu mainMenu = new MainMenu(facilityControl);
                CarWash carWash = new CarWash(mainMenu.Menu(), washTypeControl, washControl);
            }
        }
    }
}
