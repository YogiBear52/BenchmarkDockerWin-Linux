using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DockerBenchmark.OS
{
    [MemoryDiagnoser]
    public class MemoryAllocations
    {
        [Params(1000, 5000)]
        public int number_of_objects_to_allocate { get; set; }

        [Benchmark]
        public void HeavyMemoryAllocation()
        {
            List<ObjectToAllocate> objects = new List<ObjectToAllocate>();
            for (int i = 0; i < number_of_objects_to_allocate; i++)
            {
                objects.Add(new ObjectToAllocate());
            }
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
