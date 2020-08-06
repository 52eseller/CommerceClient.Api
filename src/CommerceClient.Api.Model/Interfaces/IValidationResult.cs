using CommerceClient.Api.Model.Misc;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.Interfaces
{
    public interface IValidationResult
    {
        /// <summary>
        /// Gets a value if the validation was successful.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Returns a coarse elaboration of a failed validation. (or OK)
        /// </summary>
        ValidationResult.ResultCodes Result { get; }

        /// <summary>
        /// Optional unique non-localized string
        /// </summary>
        [CanBeNull]
        string ErrorCode { get; }

        /// <summary>
        /// Localized message if validation failed.
        /// </summary>
        [CanBeNull]
        string ErrorMessage { get; }

        /// <summary>
        /// List of optional messages. These messages are informational only, and may be returned both when validation succeeds or fails,
        /// but even if a message has <see cref="Types.Severity.Error"/>, the validation may still be a success.
        /// </summary>
        [NotNull]
#pragma warning disable CA1819 // Properties should not return arrays
        IValidationMessage[] Messages { get; }
#pragma warning restore CA1819 // Properties should not return arrays
    }
}
