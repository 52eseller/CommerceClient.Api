using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using CommerceClient.Api.Model.ResponseModels.Menu;
using Newtonsoft.Json.Linq;

namespace CommerceClient.Api.Model.JsonConverters
{
    public class MenuKeyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(MenuKey);

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
        {
            var obj = JObject.Load(reader);
            var menuId = (int)obj["menuId"];

            switch ((string)obj["menuKind"])
            {
                case "topmenu":
                    return new MenuKey(menuId, MenuKind.InfoMenuTop);

                case "bottommenu":
                    return new MenuKey(menuId, MenuKind.InfoMenuBottom);

                case "faq":
                    return new MenuKey(menuId, MenuKind.InfoMenuFaq);

                default:
                    if (!Enum.TryParse(
                            (string)obj["menuKind"],
                            true,
                            out MenuKind mk
                        ))
                    {
                        throw new Exception($"menuKind {(string)obj["menuKind"]} is not supported.");
                    }

                    return new MenuKey(menuId, mk);
            }
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                var mk = (MenuKey)value;

                writer.WriteStartObject();
                writer.WritePropertyName("menuId");
                writer.WriteValue(mk.MenuItemID);
                writer.WritePropertyName("menuKind");
                switch (mk.MenuKind)
                {
                    case MenuKind.InfoMenuTop:
                        writer.WriteValue("topmenu");
                        break;
                    case MenuKind.InfoMenuBottom:
                        writer.WriteValue("bottommenu");
                        break;
                    case MenuKind.InfoMenuFaq:
                        writer.WriteValue("faq");
                        break;
                    default:
                        writer.WriteValue(mk.MenuKind.ToString().ToLowerInvariant());
                        break;
                }

                writer.WriteEndObject();
            }
        }
    }
}
