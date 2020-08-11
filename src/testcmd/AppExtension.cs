using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Coverage
{
    public static class AppExtensions
    {
        public static string ToJsonRaw<T>(
            [CanBeNull] this T source
        ) where T : class
        {
            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(
                source,
                null
            ))
            {
                return null;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(source);
        }
    }
}
