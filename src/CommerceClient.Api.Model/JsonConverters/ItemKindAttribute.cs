using CommerceClient.Api.Model.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.JsonConverters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ItemKindAttribute : Attribute
    {
        /// <summary>
        /// Specifies the kind of item that a particular item stores, facilitating Google JSON Style Guide https://google.github.io/styleguide/jsoncstyleguide.xml?showone=data.kind#data.kind
        /// </summary>
        public string ItemKind { get; set; }
        public LinkRel LinkRel { get; set; }
    }
}
