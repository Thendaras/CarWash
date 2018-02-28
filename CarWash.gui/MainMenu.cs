using CarWash.Api;
using CarWash.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.gui
{
    public class MainMenu
    {
        private Dictionary<int, Facility> _facilities;

        public MainMenu(FacilityControl facilityControl)
        {
            _facilities = facilityControl.GetFacilities().ToDictionary(fac => fac.ID);
        }
        public Facility Menu()
        {
            Console.Clear();
            Console.WriteLine("CarWash v1.0");
            Console.WriteLine("Choose Facility");

            foreach (KeyValuePair<int, Facility> f in _facilities)
            {
                Console.WriteLine($"{f.Key}. {f.Value.Location}");
            }
            var info = Console.ReadKey();
            int result;
            bool existed = false;
            Facility foundFacility = null;
            while (!existed)
            {
                if (Int32.TryParse(info.KeyChar.ToString(), out result))
                {
                    if (_facilities.TryGetValue(result, out foundFacility))
                    {
                        existed = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid facility ID");
                    }
                }
            }
            return foundFacility;
        }  
    }
}
