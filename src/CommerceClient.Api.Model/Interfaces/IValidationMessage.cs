using CommerceClient.Api.Model.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.Interfaces
{
    /// <summary>
    /// An informational, localized message accompanying a validation.
    /// </summary>
    public interface IValidationMessage
    {
        /// <summary>
        /// The severity of the message. 
        /// </summary>
        Severity Severity { get; }

        /// <summary>
        /// Localized message.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// The result code for this particular message, detailing what caused the message
        /// </summary>
        ValidationResult.ResultCodes ResultCode { get; }

        /// <summary>
        /// An invariant text string containing identification of the error 
        /// i.e. a never-changing non-localized text code usable for programmatic handling of the message.
        /// </summary>
        string ErrorCode { get; }

        /// <summary>
        /// If a message is issued due to a specific field, property, line or item etc,
        /// the <see cref="Kind"/> will tell what kind of item caused the message.
        /// May be null.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Details exactly what item of <see cref="Kind"/> caused the message.
        /// May be null.
        /// </summary>
        string Reference { get; }
    }
}
