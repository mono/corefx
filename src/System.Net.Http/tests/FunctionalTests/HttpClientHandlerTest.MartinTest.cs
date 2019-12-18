// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Net.Sockets;
using System.Net.Test.Common;
using System.Text;
using System.Threading.Tasks;

using Microsoft.DotNet.XUnitExtensions;

using Xunit;
using Xunit.Abstractions;

namespace System.Net.Http.Functional.Tests
{
    using Configuration = System.Net.Test.Common.Configuration;

    public class HttpClientHandler_MartinTest : HttpClientHandlerTestBase
    {
        public HttpClientHandler_MartinTest(ITestOutputHelper output) : base(output) { }

        [ConditionalFact]
        public async Task MartinTest()
        {
            throw new SkipTestException("I LIVE ON THE MOON!");
        }
    }
}
