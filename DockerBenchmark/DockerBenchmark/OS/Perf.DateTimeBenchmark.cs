// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;
using System;

namespace DockerBenchmark.OS
{
    public class Perf_DateTimeBenchmark
    {
        [Benchmark]
        public DateTime GetNow() => DateTime.Now;

        [Benchmark]
        public DateTime GetUtcNow() => DateTime.UtcNow;
    }
}
