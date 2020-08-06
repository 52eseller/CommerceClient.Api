using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.JsonConverters
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ApiDocJsonContractAttribute : Attribute
    {
        public bool IsLikeEnum { get; set; }
        public string EnumValues { get; set; }
    }
}
