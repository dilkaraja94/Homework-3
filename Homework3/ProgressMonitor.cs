using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework3 {
    internal class ProgressMonitor {
        private readonly List<long> _results;
        public long TotalCount = 0;
        public Monitor monitor = new Monitor(); 
        public ProgressMonitor(List<long> results) {
            _results = results;
        }
        public void Run() {
            while (true) {
                Thread.Sleep(100); 
                monitor.Enter(); 
                if (_results.Count > 0)
                {
                    monitor.Wait();
                }
                var currentcount = _results.Count;   
                TotalCount += currentcount;
                _results.Clear(); 
                monitor.Pulse();
                monitor.Exit();
                if (currentcount > 0) {
                    Console.WriteLine("{0} primes found so far", TotalCount);
                }
            }
        }
    }
}