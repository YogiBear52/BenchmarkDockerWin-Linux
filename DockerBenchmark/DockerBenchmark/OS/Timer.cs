// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DockerBenchmark.OS
{
    public class Perf_Timer
    {
        private readonly Timer[] _timers = new Timer[1_000_000];
        private readonly Task[] _tasks = new Task[Environment.ProcessorCount];

        [Benchmark]
        public void ShortScheduleAndDispose() => new Timer(_ => { }, null, 50, -1).Dispose();

        [Benchmark]
        public void LongScheduleAndDispose() => new Timer(_ => { }, null, int.MaxValue, -1).Dispose();

        [Benchmark]
        public void ScheduleManyThenDisposeMany()
        {
            Timer[] timers = _timers;

            for (int i = 0; i < timers.Length; i++)
            {
                timers[i] = new Timer(_ => { }, null, int.MaxValue, -1);
            }

            foreach (Timer timer in timers)
            {
                timer.Dispose();
            }
        }
    }
}
