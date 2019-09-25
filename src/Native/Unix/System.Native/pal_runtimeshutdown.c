// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#include "pal_runtimeshutdown.h"
#include "pal_types.h"
#include <stdio.h>
#include <sys/utsname.h>

int32_t SystemNative_IsRuntimeShuttingDown(void)
{
    // Mono provides a custom implementation.
    return 0;
}
