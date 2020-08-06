using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.Misc
{
    [Serializable]
    public class ValidationMessage
    {
        public ValidationMessage(
            Severity severity,
            string message,
            ValidationResult.ResultCodes resultCode,
            string errorCode,
            string kind,
            string reference
        )
        {
            _Severity = severity;
            _Message = message;
            _ErrorCode = errorCode;
            _ResultCode = resultCode;
            _Kind = kind;
            _Reference = reference;
        }

        public ValidationMessage(
            Severity severity,
            string message,
            ValidationResult.ResultCodes resultCode,
            string errorCode
        )
        {
            _Severity = severity;
            _Message = message;
            _ErrorCode = errorCode;
            _ResultCode = resultCode;
        }

        public ValidationMessage(Severity severity, string message)
        {
            _Severity = severity;
            _Message = message;
            _ErrorCode = null;
            _ResultCode = ValidationResult.ResultCodes.Other;
        }

        private Severity _Severity;

        private string _Message;

        private string _ErrorCode;

        private ValidationResult.ResultCodes _ResultCode;

        private string _Kind;
      
        private string _Reference;

        /// <inheritdoc />
        public Severity Severity => _Severity;

        /// <inheritdoc />
        public string Message => _Message;

        /// <inheritdoc />
        public string ErrorCode => _ErrorCode;

        /// <inheritdoc />
        public ValidationResult.ResultCodes ResultCode => _ResultCode;

        /// <inheritdoc />
        public string Kind => _Kind;

        /// <inheritdoc />
        public string Reference => _Reference;
    }
}
