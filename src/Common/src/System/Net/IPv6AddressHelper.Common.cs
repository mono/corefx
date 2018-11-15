// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System
{
    internal static partial class IPv6AddressHelper
    {
        // fields
        private const int NumberOfLabels = 8;
        // Lower case hex, no leading zeros
        private const string CanonicalNumberFormat = "{0:x}";
        private const string EmbeddedIPv4Format = ":{0:d}.{1:d}.{2:d}.{3:d}";
        private const char Separator = ':';
    }
}
