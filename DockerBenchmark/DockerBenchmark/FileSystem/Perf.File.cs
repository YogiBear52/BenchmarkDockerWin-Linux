// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace DockerBenchmark.FileSystem
{
    public class Perf_File
    {
        private const int DeleteteInnerIterations = 10;

        private string _testFilePath;
        private string[] _filesToRemove;

        #region Exists

        [GlobalSetup(Target = nameof(Exists))]
        public void SetupExists()
        {
            _testFilePath = GetTestFilePath();
            File.Create(_testFilePath).Dispose();
        }

        [Benchmark]
        public void Exists() => File.Exists(_testFilePath);

        [GlobalCleanup(Target = nameof(Exists))]
        public void CleanupExists() => File.Delete(_testFilePath);

        #endregion

        #region Delete

        [IterationSetup(Target = nameof(Delete))]
        public void SetupDeleteIteration()
        {
            var testFile = GetTestFilePath();
            _filesToRemove = Enumerable.Range(1, DeleteteInnerIterations).Select(index => testFile + index).ToArray();
            foreach (var file in _filesToRemove)
                File.Create(file).Dispose();
        }

        [Benchmark(OperationsPerInvoke = DeleteteInnerIterations)]
        public void Delete()
        {
            var filesToRemove = _filesToRemove;

            foreach (var file in filesToRemove)
                File.Delete(file);
        }

        #endregion

        #region Private Methods

        public static string GetTestFilePath() => Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

        #endregion
    }
}
