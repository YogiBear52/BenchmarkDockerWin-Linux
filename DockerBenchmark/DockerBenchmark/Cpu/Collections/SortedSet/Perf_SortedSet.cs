﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace DockerBenchmark.Cpu.Collections.SortedSet
{
    public class Perf_SortedSet
    {
        private SortedSet<int> _set;

        [GlobalSetup]
        public void Setup()
        {
            _set = new SortedSet<int>();
            for (int n = 0; n < 100_000; n++)
            {
                _set.Add(n);
            }
        }

        [Benchmark]
        public int Min() => _set.Min;

        [Benchmark]
        public int Max() => _set.Max;
    }
}
