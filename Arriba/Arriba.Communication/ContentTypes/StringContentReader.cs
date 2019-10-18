﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Arriba.Communication.ContentTypes
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    ///     String content reader.
    /// </summary>
    public sealed class StringContentReader : IContentReader
    {
        IEnumerable<string> IContentReader.ContentTypes
        {
            get { yield return "text/plain"; }
        }

        bool IContentReader.CanRead<T>()
        {
            return typeof(T) == typeof(string);
        }

        async Task<T> IContentReader.ReadAsync<T>(Stream input)
        {
            using (var reader = new StreamReader(input))
            {
                return (T) (object) await reader.ReadToEndAsync();
            }
        }
    }
}