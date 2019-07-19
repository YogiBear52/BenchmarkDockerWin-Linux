// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BenchmarkDotNet.Attributes;

namespace System.Threading.Tasks.Tests
{
    public class AsyncMethods
    {
        [Benchmark(OperationsPerInvoke = 100_000)]
        public async Task EmptyAsyncMethodInvocation()
        {
            for (int i = 0; i < 100_000; i++)
            {
                await EmptyAsync();
            }

            async Task EmptyAsync() { }
        }

        [Benchmark(OperationsPerInvoke = 1_000)]
        public async Task SingleYieldMethodInvocation()
        {
            for (int i = 0; i < 1_000; i++)
            {
                await Yield();
            }

            async Task Yield() => await Task.Yield();
        }
    }
}
