using BenchmarkDotNet.Attributes;
using System;
using System.IO;
using System.Linq;

namespace DockerBenchmark.FileSystem
{
    public class Perf_Directory
    {
        private const int CreateInnerIterations = 10;

        private readonly string _testFile = GetTestFilePath();
        private string[] _directoriesToCreate;

        [Benchmark]
        public string GetCurrentDirectory() => Directory.GetCurrentDirectory();

        #region CreateDirectory

        [GlobalSetup(Target = nameof(CreateDirectory))]
        public void SetupCreateDirectory()
        {
            var testFile = GetTestFilePath();
            _directoriesToCreate = Enumerable.Range(1, CreateInnerIterations).Select(index => testFile + index).ToArray();
        }

        [Benchmark(OperationsPerInvoke = CreateInnerIterations)]
        public void CreateDirectory()
        {
            var directoriesToCreate = _directoriesToCreate;
            foreach (var directory in directoriesToCreate)
                Directory.CreateDirectory(directory);
        }

        [IterationCleanup(Target = nameof(CreateDirectory))]
        public void CleanupDirectoryIteration()
        {
            foreach (var directory in _directoriesToCreate)
                Directory.Delete(directory);
        }

        #endregion

        #region Exists

        [GlobalSetup(Target = nameof(Exists))]
        public void SetupExists() => Directory.CreateDirectory(_testFile);

        [Benchmark]
        public bool Exists() => Directory.Exists(_testFile);

        [GlobalCleanup(Target = nameof(Exists))]
        public void CleanupExists() => Directory.Delete(_testFile);

        #endregion

        #region GetLogicalDrives

        [Benchmark]
        public string[] GetLogicalDrives() => Environment.GetLogicalDrives();

        #endregion

        #region Private Methods

        private static string GetTestFilePath() => Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

        #endregion
    }
}
