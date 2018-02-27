using CarWash.Entities;
using CarWash.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarWash.Api
{
    public class UserControl
    {
        private ProcessService _processService;
        public UserControl(ProcessService processService)
        {
            _processService = processService;
        }
        public async Task StartWash(WashType washType)
        {
            var token = new CancellationToken();
            
            foreach(Process process in washType.Processes)
            {
                await _processService.StartProcess(process.Duration, token, new Progress<WashProgress>(PrintProgress));
            }
        }
        private void PrintProgress(WashProgress progress)
        {
            Console.WriteLine($"{progress.CurrentProgress}/{progress.MaxProgress}");
        }
    }
}
