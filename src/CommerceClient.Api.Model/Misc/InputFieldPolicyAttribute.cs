using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.Misc
{
    [AttributeUsage(
        AttributeTargets.Property
    )]
    public sealed class InputFieldPolicyAttribute : Attribute
    {
        public const string NoExplicitPolicyName = "(implicit)";
        public InputFieldPolicyAttribute(string name) => Name = name;

        /// <summary>
        /// The name of the policy
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets a value indicating if leading and trailing spaces are to be trimmed. The default is true.
        /// </summary>
        public bool TrimLeadingAndTrailingSpaces { get; set; } = true;

        /// <summary>
        /// True indicates that no policy should be used. The is the same as not specifying th attribute, but it avoids any
        /// errors that may arise when trying to validate against policies without any policy specified.
        /// The default is false.
        /// </summary>
        public bool IgnorePolicy { get; set; }
        /// <summary>
        /// Indicates that even though there is no policy for the field, the property will be expected to have a value.
        /// </summary>
        public bool IsRequiredByConvention { get; set; }
    }
}
