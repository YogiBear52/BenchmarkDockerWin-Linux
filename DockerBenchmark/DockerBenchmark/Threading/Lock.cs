// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;
using System.Threading;

namespace DockerBenchmark.Threading
{
    public class Lock
    {
        ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

        [Benchmark]
        public void ReaderWriterLockSlimPerf()
        {
            ReaderWriterLockSlim rwLock = _rwLock;

            rwLock.EnterReadLock();
            rwLock.ExitReadLock();
        }
    }
}