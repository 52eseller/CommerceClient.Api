using CommerceClient.Api.Model.Misc;
using Newtonsoft.Json;
using System;

namespace CommerceClient.Api.Model.JsonConverters
{
    [ApiDocJsonContract(IsLikeEnum = true, EnumValues = "debug,info,warning,error,fatal,security")]
    public class SeverityConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(Severity);

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            Newtonsoft.Json.JsonSerializer serializer
        )
        {
            var obj = reader.Value as string;

            switch (obj)
            {
                case "debug":
                    return Severity.Debug;

                case "lowPri":
                    return Severity.Debug;

                case "info":
                    return Severity.Info;

                case "warning":
                    return Severity.Warning;

                case "error":
                    return Severity.Error;

                case "fatal":
                    return Severity.Fatal;

                case "security":
                    return Severity.Security;


                default:
                    if (!Enum.TryParse(
                            obj,
                            true,
                            out Severity mk
                        ))
                    {
                        throw new Exception($"Severity '{obj}' is not supported.");
                    }

                    return mk;
            }
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                var mk = (Severity)value;

                switch (mk)
                {
                    case Severity.Debug:
                        writer.WriteValue("lowPri");
                        break;
                    case Severity.Info:
                        writer.WriteValue("info");
                        break;
                    case Severity.Warning:
                        writer.WriteValue("warning");
                        break;
                    case Severity.Error:
                        writer.WriteValue("error");
                        break;
                    case Severity.Fatal:
                        writer.WriteValue("fatal");
                        break;
                    case Severity.Security:
                        writer.WriteValue("security");
                        break;
                    default:
                        writer.WriteValue("**" + mk.ToString().ToLowerInvariant() + "**");
                        break;
                }
            }
        }
    }
}
