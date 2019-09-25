// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Sys
    {
#if MONO
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
#else
        [DllImport(Libraries.SystemNative, EntryPoint = "SystemNative_GetDomainSocketSizes")]
#endif
        internal static extern void GetDomainSocketSizes(out int pathOffset, out int pathSize, out int addressSize);
    }
}
