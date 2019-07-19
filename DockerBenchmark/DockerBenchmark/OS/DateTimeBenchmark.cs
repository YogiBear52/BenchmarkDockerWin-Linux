// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;

namespace System.Tests
{
    public class DateTimeBenchmark
    {
        [Benchmark]
        public DateTime GetNow() => DateTime.Now;

        [Benchmark]
        public DateTime GetUtcNow() => DateTime.UtcNow;
    }
}
