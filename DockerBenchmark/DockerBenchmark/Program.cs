using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using System;
using System.Linq;

namespace DockerBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("About To Start");

            var config = DefaultConfig.Instance.With(Job.Default.With(InProcessEmitToolchain.Instance));

            var benchmarkClasses = 
                typeof(Program).Assembly.GetTypes()
                    .Where(_ => _.IsClass && _.GetMethods().Any(m => m.GetCustomAttributes(typeof(BenchmarkAttribute), false).Length > 0))
                    .ToList();


            benchmarkClasses.ForEach(_ => BenchmarkRunner.Run(_, config));
            //var summary = BenchmarkRunner.Run<MutexBenchmark>(config);

            Console.WriteLine("Finished");
        }
    }
}
