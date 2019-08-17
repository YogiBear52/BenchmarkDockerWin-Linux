using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerBenchmark.Threading
{
    public class Multitasking
    {
        [Params(100000)]
        public int number_of_tasks {get;set;}


        [Benchmark]
        public async Task CuncurrentInsertionsToDictionary()
        {
            int[] array = Enumerable.Range(1, number_of_tasks).ToArray();

            ConcurrentDictionary<int, int> cucnrentDictionary = new ConcurrentDictionary<int, int>();
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < number_of_tasks; i++)
            {
                int number = array[i];
                tasks.Add(Task.Run(() =>
                {
                    cucnrentDictionary.TryAdd(number, number);
                }));
            }

            await Task.WhenAll(tasks);
        }

        [Benchmark]
        public async Task RunningMultipleTasksSynchronously()
        {
            int[] array = Enumerable.Range(1, number_of_tasks).ToArray();

            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < number_of_tasks; i++)
            {
                int number = array[i];
                await Task.Run(() =>
                {
                    dictionary.TryAdd(number, number);
                });
            }
        }
    }
}
