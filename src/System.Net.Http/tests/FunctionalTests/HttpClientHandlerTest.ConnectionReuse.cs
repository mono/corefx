// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Net.Sockets;
using System.Net.Test.Common;
using System.Text;
using System.Threading.Tasks;

#if !MONO
using Microsoft.DotNet.XUnitExtensions;
using Microsoft.DotNet.RemoteExecutor;
#endif

using Xunit;
using Xunit.Abstractions;

namespace System.Net.Http.Functional.Tests
{
    using Configuration = System.Net.Test.Common.Configuration;

    public class HttpClientHandler_ConnectionReuse_Test : HttpClientHandlerTestBase
    {
        public HttpClientHandler_ConnectionReuse_Test(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task MartinTest()
        {
            using (HttpClientHandler handler = CreateHttpClientHandler())
            {
                using (HttpClient client = CreateHttpClient(handler))
                {
                    await LoopbackServer.CreateServerAsync(async (server, url) =>
                    {
                        Console.Error.WriteLine($"GOT SERVER: {server} {url}");
                        Task serverTask1 = server.AcceptConnectionAsync(async connection1 =>
                        {
                            Console.Error.WriteLine($"GOT CONNECTION: {connection1.Socket.RemoteEndPoint}");
                            await connection1.ReadRequestHeaderAsync();
                            var body = await connection1.ReadRequestBodyAsync();
                            await connection1.SendResponseAsync(HttpStatusCode.OK, null, "hello");
                            await Task.Delay(500);
                            connection1.Dispose();
                        });

                        var data = new FormUrlEncodedContent(new Dictionary<string, string> { });
                        var result = await client.PostAsync(url, data);
                        Console.Error.WriteLine($"TEST: ${result}");

                        await serverTask1;

                        Task serverTask2 = server.AcceptConnectionAsync(async connection2 =>
                        {
                            Console.Error.WriteLine($"GOT CONNECTION: {connection2.Socket.RemoteEndPoint}");
                            await connection2.ReadRequestHeaderAsync();
                            var body = await connection2.ReadRequestBodyAsync();
                            await connection2.SendResponseAsync(HttpStatusCode.OK, null, "hello");
                            await Task.Delay(500);
                            connection2.Dispose();
                        });

                        data = new FormUrlEncodedContent(new Dictionary<string, string> { });
                        result = await client.PostAsync(url, data);
                        Console.Error.WriteLine($"TEST: ${result}");

                    });
                }
            }
        }
    }
}
