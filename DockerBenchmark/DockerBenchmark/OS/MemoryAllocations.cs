using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerBenchmark.OS
{
    [MemoryDiagnoser]
    public class MemoryAllocations
    {
        [Params(1000, 5000)]
        public int number_of_objects_to_allocate { get; set; }

        [Benchmark]
        public void MemoryAllocation()
        {
            List<ObjectToAllocate> objects = new List<ObjectToAllocate>();
            for (int i = 0; i < number_of_objects_to_allocate; i++)
            {
                objects.Add(new ObjectToAllocate());
            }
        }

        [Benchmark]
        public void ParallelMemoryAllocation()
        {
            List<ObjectToAllocate> objects = new List<ObjectToAllocate>();

            Parallel.For(0, number_of_objects_to_allocate, _ =>
            {
                objects.Add(new ObjectToAllocate());
            });
        }
    }


    public class ObjectToAllocate
    {
        public int[] ArrayOfInts{ get;}
        public string[] ArrrayOfStrings { get; }
        public DateTime[] ArrayOfDateTimes { get; }

        public ObjectToAllocate()
        {
            ArrayOfDateTimes = Enumerable.Range(1, 1000).Select(_ => DateTime.Now).ToArray();
            ArrrayOfStrings = Enumerable.Range(1, 1000).Select(_ =>_.ToString()).ToArray();
            ArrayOfInts = Enumerable.Range(1, 1000).Select(_ => _).ToArray();
        }
    }
}
