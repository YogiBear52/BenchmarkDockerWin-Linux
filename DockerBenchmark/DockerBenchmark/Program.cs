using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using System;
using System.Linq;
using System.Threading;

namespace DockerBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("About To Start");

            try
            {
                var config = DefaultConfig.Instance
                    .With(Job.Default.With(InProcessEmitToolchain.Instance));
                    //.With(CsvMeasurementsExporter.Default, CsvExporter.Default, RPlotExporter.Default);

                var benchmarkClasses =
                    typeof(Program).Assembly.GetTypes()
                        .Where(_ => _.IsClass && _.GetMethods().Any(m => m.GetCustomAttributes(typeof(BenchmarkAttribute), false).Length > 0))
                        .Skip(20).Take(5).ToList();

                Console.WriteLine(benchmarkClasses.Count);

                benchmarkClasses.ForEach(_ =>
                {
                    try
                    {
                        BenchmarkRunner.Run(_, config);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"The benchmark of type '{_.FullName}' Has failed. {e.ToString()}");
                    }
                });
                //var summary = BenchmarkRunner.Run<RegexRedux>(config);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
            Console.WriteLine("Finished");

            while (true)
            {
                Console.WriteLine("Hanging");
                Thread.Sleep(10000);
            }
        }
    }
}
