using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DockerBenchmark.OS
{
    public class MutexBenchmark
    {
        private static Mutex mut;
        private const int numIterations = 5;
        private const int numThreads = 6;

        [IterationCleanup]
        public void CleanupIteration() => mut.Dispose(); 

        [IterationSetup(Target = nameof(StartThreads))]
        public void SetupArrayIteration() => mut = new Mutex();


        [Benchmark]
        public void StartThreads()
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < numThreads; i++)
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProc));
                newThread.Name = String.Format("Thread{0}", i + 1);
                newThread.Start();
                threads.Add(newThread);
            }

            // Wait for all threads to finish
            threads.ForEach(th =>
            {
                th.Join();
            });
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        private static void UseResource()
        {
            // Wait until it is safe to enter, and do not enter if the request times out.
            if (mut.WaitOne(50))
            {
                // Simulate some work.
                Thread.Sleep(100);

                mut.ReleaseMutex();
            }
            else
            {
                // Not entered
            }
        }
    }
}
