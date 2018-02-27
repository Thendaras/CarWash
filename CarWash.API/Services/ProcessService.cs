﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarWash.API.Api;
using CarWash.API.Repositories;
using CarWash.API.Repositories.Process;
using CarWash.Entities;
using CarWash.Repositories;

namespace CarWash.Services
{
    public class ProcessService
    {
        private IProcessRepository _processRepository;
        public ProcessService(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }
        public Task StartProcess(int duration, CancellationToken ct, IProgress<WashProgress> progressObserver)
        {
            return Task.Factory.StartNew(() =>
            {
                    for (int i = 0; i <= duration; i+=10)
                    {
                        ct.ThrowIfCancellationRequested();
                        progressObserver.Report(new WashProgress{ CurrentProgress = i, MaxProgress = duration});
                        Thread.Sleep(10);
                    }
            });
        }
    }
}