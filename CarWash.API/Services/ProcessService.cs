﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Api;
using CarWash.Repositories;
using CarWash.Repositories.Process;
using CarWash.Entities;

namespace CarWash.Services
{
    public class ProcessService
    {
        private IProcessRepository _processRepository;
        public ProcessService(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }
        public Task StartProcess(Process process, IProgress<WashProgress> progressObserver)
        {
            return Task.Factory.StartNew(() =>
            {
                    for (int i = 0; i <= process.Duration; i+=100)
                    {
                        progressObserver.Report(new WashProgress{ CurrentProgress = i, MaxProgress = process.Duration, Name = process.Name});
                        Thread.Sleep(100);
                    }
            });
        }
    }
}
