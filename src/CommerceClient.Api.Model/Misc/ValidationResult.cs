using CommerceClient.Api.Model.Interfaces;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommerceClient.Api.Model.Misc
{
    /// <summary>
    /// Instance of this type is typically returned by method, that validates or perform actions, and is used to give a bit more information than a plain boolean can give.
    /// </summary>
    [Serializable]
    public sealed class ValidationResult
    {
        /// <summary>
        /// Creates a new instance set to <see cref="IsValid"/> = true.
        /// </summary>
        public ValidationResult()
        {
            _IsValid = true;
            _Result = ResultCodes.Ok;
            var emptyList = new List<ValidationMessage>();
            _Messages = emptyList.ToArray();
        }

        /// <summary>
        /// Creates a new instance set to <see cref="IsValid"/> = true.
        /// </summary>
        public ValidationResult([NotNull] IValidationMessage message)
        {
            _IsValid = true;
            _Result = ResultCodes.Ok;
            _Messages = new[]
            {
                message as ValidationMessage ??
                new ValidationMessage(
                    message.Severity,
                    message.Message,
                    message.ResultCode,
                    message.ErrorCode,
                    message.Kind,
                    message.Reference
                )
            };
            _ErrorMessage = _Messages.FirstOrDefault()?.Message;
            _ErrorCode = _Messages.FirstOrDefault()?.ErrorCode;
        }

        /// <summary>
        /// Creates a new instance set to <see cref="IsValid"/> = true.
        /// </summary>
        public ValidationResult([NotNull] IValidationMessage[] messages)
        {
            _IsValid = true;
            _Result = ResultCodes.Ok;
            _Messages = messages as ValidationMessage[] ??
                        messages.Select(
                                x => new ValidationMessage(
                                    x.Severity,
                                    x.Message,
                                    x.ResultCode,
                                    x.ErrorCode,
                                    x.Kind,
                                    x.Reference
                                )
                            )
                            .ToArray();
            _ErrorMessage = _Messages.FirstOrDefault()?.Message;
            _ErrorCode = _Messages.FirstOrDefault()?.ErrorCode;
        }

        /// <summary>
        /// Creates a new instance with supplied values. 
        /// <see cref="Messages"/> are populated with 1 row with the messages and
        ///  <see cref="IValidationMessage.Severity"/> set to <see cref="Severity.Error"/> is not valid, otherwise set to <see cref="Severity.Warning"/>.
        /// </summary>
        /// <param name="valid"></param>
        /// <param name="errorMessage"></param>
        /// <param name="resultCode"></param>
        /// <param name="errorCode"></param>
        public ValidationResult(
            bool valid,
            string errorMessage,
            ResultCodes resultCode,
            string errorCode
        )
        {
            _IsValid = valid;
            _Result = resultCode;
            _ErrorCode = errorCode;
            _ErrorMessage = errorMessage;
            _Messages = new[]
            {
                new ValidationMessage(
                    IsValid ? Severity.Warning : Severity.Error,
                    errorMessage,
                    resultCode,
                    errorCode
                )
            };
        }

        /// <summary>
        /// Creates a new instance with supplied values. 
        /// <see cref="Messages"/> are populated with 1 row with the messages and
        ///  <see cref="IValidationMessage.Severity"/> set to <see cref="Severity.Error"/> is not valid, otherwise set to <see cref="Severity.Warning"/>.
        /// </summary>
        /// <param name="valid"></param>
        /// <param name="errorMessage"></param>
        /// <param name="resultCode"></param>
        /// <param name="errorCode"></param>
        /// <param name="kind"></param>
        /// <param name="reference"></param>
        public ValidationResult(
            bool valid,
            string errorMessage,
            ResultCodes resultCode,
            string errorCode,
            string kind,
            string reference
        )
        {
            _IsValid = valid;
            _Result = resultCode;
            _ErrorCode = errorCode;
            _ErrorMessage = errorMessage;
            _Messages = new[]
            {
                new ValidationMessage(
                    IsValid ? Severity.Warning : Severity.Error,
                    errorMessage,
                    resultCode,
                    errorCode,
                    kind,
                    reference
                )
            };
        }

        /// <summary>
        /// Creates a new instance with supplied values.
        /// </summary>
        /// <param name="valid"></param>
        /// <param name="errorMessage"></param>
        /// <param name="resultCode"></param>
        /// <param name="errorCode"></param>
        /// <param name="messages"></param>
        public ValidationResult(
            bool valid,
            string errorMessage,
            ResultCodes resultCode,
            string errorCode,
            [NotNull] IEnumerable<IValidationMessage> messages
        )
        {
            _IsValid = valid;
            _Result = resultCode;
            _ErrorCode = errorCode;
            _ErrorMessage = errorMessage;
            _Messages = messages as ValidationMessage[] ??
                        messages.Select(
                                x => new ValidationMessage(
                                    x.Severity,
                                    x.Message,
                                    x.ResultCode,
                                    x.ErrorCode,
                                    x.Kind,
                                    x.Reference
                                )
                            )
                            .ToArray();
        }

        /// <summary>
        /// Changes the validation state of the instance.
        /// </summary>
        /// <param name="isValid"></param>
        /// <returns></returns>
        [NotNull]
        public ValidationResult SetValid(bool isValid)
        {
            _IsValid = isValid;
            return this;
        }

        private bool _IsValid;

        private ResultCodes _Result;

        private string _ErrorCode;

        private string _ErrorMessage;

        private ValidationMessage[] _Messages;

        /// <inheritdoc />
        public bool IsValid => _IsValid;

        /// <inheritdoc />
        public ResultCodes Result => _Result;

        /// <inheritdoc />
        public string ErrorCode => _ErrorCode;

        /// <inheritdoc />
        public string ErrorMessage => _ErrorMessage;

        /// <inheritdoc />
#pragma warning disable CA1819 // Properties should not return arrays
        public IValidationMessage[] Messages => _Messages.Cast<IValidationMessage>().ToArray();
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Returns am instance, that indicates validation passed with no complaints.
        /// </summary>
        public static ValidationResult Valid { get; }
            = new ValidationResult
            {
                _ErrorMessage = null,
                _ErrorCode = null,
                _IsValid = true,
                _Result = ResultCodes.Ok
            };

        public enum ResultCodes
        {
            /// <summary>
            /// The validation was fine.
            /// </summary>
            Ok,

            /// <summary>
            /// The validation was fine (if IsValid is set), but with warnings.
            /// </summary>
            Warning,

            /// <summary>
            /// The primary resource was not found.
            /// </summary>
            NotFound,

            /// <summary>
            /// A parameter was missing or invalid in the given operation.
            /// </summary>
            Parameter,

            /// <summary>
            /// A constraint prohibits the proposed action.
            /// </summary>
            ConstraintFailure,

            /// <summary>
            /// Insufficient privileges to perform the proposed action.
            /// </summary>
            UnAuthorized,

            /// <summary>
            /// Used if none of the other codes applies (usually <see cref="ConstraintFailure"/> will fit the bill).
            /// </summary>
            Other
        }
    }
}
