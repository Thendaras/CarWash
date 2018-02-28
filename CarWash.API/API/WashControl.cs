using CarWash.Entities;
using CarWash.Repositories.Order;
using CarWash.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarWash.Api
{
    public class WashControl
    {
        private ProcessService _processService;
        private IOrderRepository _orderRepository;
        public WashControl(ProcessService processService, IOrderRepository orderRepository)
        {
            _processService = processService;
            _orderRepository = orderRepository;
        }
        public async Task<bool> StartWash(Facility facility, WashType washType, CancellationToken ct, IProgress<WashProgress> progressObserver)
        {
            Order currentOrder = new Order
            {
                Started = DateTime.Now,
                WashType = washType,
                WashTypeID = washType.ID,
                Price = washType.Processes.Sum(x => x.Cost),
                Facility = facility,
                FacilityID = facility.ID
            };
            foreach(Entities.Process process in washType.Processes)
            {
                await _processService.StartProcess(process, progressObserver);
                if(ct.IsCancellationRequested)
                {
                    currentOrder.Aborted = DateTime.Now;
                    _orderRepository.Create(currentOrder);
                    return false;
                }
            }
            currentOrder.Completed = DateTime.Now;
            _orderRepository.Create(currentOrder);
            return true;
        }


        private void PrintProgress(WashProgress progress)
        {
            Console.WriteLine($"{progress.CurrentProgress}/{progress.MaxProgress}");
        }
    }
}
