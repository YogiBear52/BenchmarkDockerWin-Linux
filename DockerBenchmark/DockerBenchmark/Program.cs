using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using System;
using System.Tests;

namespace DockerBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("About To Start");

            var config = DefaultConfig.Instance.With(Job.Default.With(InProcessEmitToolchain.Instance));

            if (args == null || args.Length == 0)
            {
                var summary = BenchmarkRunner.Run<DateTimeBenchmark>(config);
            }
            else
            {
                var summary1 = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            }

            Console.WriteLine("Finished");
        }
    }
}
