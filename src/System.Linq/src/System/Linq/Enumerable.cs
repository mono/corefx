// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
		// This provides the properties that two empty enumerables with the
		// same type parameter will have two iterators that have reference
		// equality. 
		internal class EmptyEnumerableInst<TElement> : IEnumerable<TElement>
		{
				static readonly IEnumerable<TElement> Instance = new TElement [0];
				static readonly IEnumerator<TElement> Iter = Instance.GetEnumerator ();

				IEnumerator IEnumerable.GetEnumerator () {
					return this.GetEnumerator ();
				}

				public IEnumerator<TElement> GetEnumerator () {
					return Iter;
				}
		}

		// Creates a global singleton for each type this is instantiated with
		internal class EmptyEnumerableSingleton<TElement>
		{
			public static readonly EmptyEnumerableInst<TElement> Instance = new EmptyEnumerableInst<TElement> ();
		}

    public static partial class Enumerable
    {
				public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source) => source;

				public static IEnumerable<TResult> Empty<TResult>() {
					// Bug #59335
					// This call has to add behavior to the return value that differs from that of Array.Empty.
					// Array.Empty<> returns an array for which two subsequent calls to GetEnumerator are allowed to
					// return different references. 
					//
					// When we call Enumerable.Empty<T> twice for the same T, the associated iterators for those types must be
					// equal.
					//
					// Note: there is a parallel implementation of Enumerable.cs in referencesource to update when changes are made
					// here
					return EmptyEnumerableSingleton<TResult>.Instance;
				}
		}
}
