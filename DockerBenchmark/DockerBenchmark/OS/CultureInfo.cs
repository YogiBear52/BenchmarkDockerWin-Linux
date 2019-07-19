// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace System.Globalization.Tests
{
    /// <summary>
    /// Performance tests for converting DateTime to different CultureInfos
    /// 
    /// Primary methods affected: Parse, ToString
    /// </summary>
    public class Perf_CultureInfo
    {
        [Benchmark]
        public CultureInfo GetNow() => CultureInfo.CurrentCulture;
    }
}
