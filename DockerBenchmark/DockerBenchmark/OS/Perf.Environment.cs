// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using BenchmarkDotNet.Attributes;

namespace DockerBenchmark.OS
{
    public class Perf_Environment
    {
        private const string Key = "7efd538f-dcab-4806-839a-972bc463a90c";

        [GlobalSetup]
        public void Setup() => Environment.SetEnvironmentVariable(Key, "value");

        [GlobalCleanup]
        public void Cleanup() => Environment.SetEnvironmentVariable(Key, null);

        [Benchmark]
        public string GetEnvironmentVariable() => Environment.GetEnvironmentVariable(Key);

        [Benchmark]
        public IDictionary GetEnvironmentVariables() => Environment.GetEnvironmentVariables();
    }
}
