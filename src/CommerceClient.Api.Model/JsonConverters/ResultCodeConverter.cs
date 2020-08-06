using CommerceClient.Api.Model.Misc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.JsonConverters
{
    [ApiDocJsonContract(
        IsLikeEnum = true,
        EnumValues = "ok,warning,notFound,constraintFailure,unAuthorized,other"
    )]
    public class ResultCodeConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanRead => false;

        /// <inheritdoc />
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
            => throw new NotImplementedException();

        public override bool CanConvert(Type objectType) => objectType == typeof(ValidationResult.ResultCodes);

        public override bool CanWrite => true;

        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer
        )
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                var mk = (ValidationResult.ResultCodes)value;

                switch (mk)
                {
                    case ValidationResult.ResultCodes.Ok:
                        writer.WriteValue("ok");
                        break;
                    case ValidationResult.ResultCodes.Warning:
                        writer.WriteValue("warning");
                        break;
                    case ValidationResult.ResultCodes.NotFound:
                        writer.WriteValue("notFound");
                        break;
                    case ValidationResult.ResultCodes.ConstraintFailure:
                        writer.WriteValue("constraintFailure");
                        break;
                    case ValidationResult.ResultCodes.UnAuthorized:
                        writer.WriteValue("unAuthorized");
                        break;
                    case ValidationResult.ResultCodes.Other:
                        writer.WriteValue("other");
                        break;
                    default:
                        writer.WriteValue("**" + mk.ToString().ToLowerInvariant() + "**");
                        break;
                }
            }
        }
    }
}
