// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Sys
    {
        internal struct TimeValPair
        {
            internal long ASec;  // access time (seconds)
            internal long AUSec; // access time (microseconds)
            internal long MSec;  // modified time (seconds)
            internal long MUSec; // modified time (microseconds)
        }

        /// <summary>
        /// Sets the last access and last modified time of a file 
        /// </summary>
        /// <param name="path">The path to the item to get time values for</param>
        /// <param name="time">The output time values of the item</param>
        /// <returns>
        /// Returns 0 on success; otherwise, returns -1 
        /// </returns>
        [DllImport(Libraries.SystemNative, EntryPoint = "SystemNative_UTimes", SetLastError = true)]
        internal static extern int UTimes(string path, ref TimeValPair times);
    }
}
