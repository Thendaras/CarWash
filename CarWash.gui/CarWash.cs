using CarWash.Api;
using CarWash.Entities;
using CarWash.Repositories.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarWash.gui
{
    public class CarWash
    {
        private WashControl _washControl;

        private Facility _currentFacility;
        private Dictionary<int, WashType> _washTypes;

        private CancellationTokenSource _cancelTokenSource;

        public CarWash(Facility facility, WashTypeControl washTypeControl, WashControl washControl)
        {
            _washControl = washControl;
            _currentFacility = facility;
            _cancelTokenSource = new CancellationTokenSource();
            _washTypes = washTypeControl.GetWashTypes().ToDictionary(x => x.ID);
            Menu();
        }
        public void Menu()
        {
            Clear();
            Console.WriteLine("Choose WashType");
            foreach (KeyValuePair<int, WashType> washType in _washTypes)
            {
                Console.WriteLine($"{washType.Key}. {washType.Value.Name}");
            }
            Task<bool> wash = _washControl.StartWash(_currentFacility, GetWashType(), _cancelTokenSource.Token, new Progress<WashProgress>(DisplayProgress));
            while(!wash.IsCompleted || wash.IsCanceled)
            {
                if(Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    _cancelTokenSource.Cancel();
                    Console.WriteLine("Canceling...");
                }
            }
        }

        public void DisplayProgress(WashProgress progress)
        {
            Console.SetCursorPosition(0, 3);
            Console.WriteLine($"{progress.Name}: {progress.CurrentProgress}/{progress.MaxProgress}");
            Console.WriteLine("Press ESC To Cancel");
        }
        public WashType GetWashType()
        {
            var info = Console.ReadKey();
            int result;
            bool existed = false;
            WashType foundWashType = null;
            while (!existed)
            {
                if (Int32.TryParse(info.KeyChar.ToString(), out result))
                {
                    if (_washTypes.TryGetValue(result, out foundWashType))
                    {
                        existed = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid WashType ID");
                    }
                }
            }
            Clear();
            return foundWashType;
        }

        private void Clear()
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("CarWash v1.0 Alpha");
            Console.WriteLine("==========================");
        }
    }
}
