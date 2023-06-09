﻿using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TPH.ViettelSignCertificate.Extensions
{
    public class LowerCasePropertyNameJsonReader : JsonTextReader
    {
        public LowerCasePropertyNameJsonReader(TextReader textReader)
            : base(textReader)
        {
        }

        public override object Value
        {
            get
            {
                if (TokenType == JsonToken.PropertyName)
                    return ((string)base.Value).ToLower();

                return base.Value;
            }
        }
    }

    public static class JsonHelper
    {
        public static JToken DeserializeWithLowerCasePropertyNames(string json)
        {
            using (TextReader textReader = new StringReader(json))
            using (JsonReader jsonReader = new LowerCasePropertyNameJsonReader(textReader))
            {
                var ser = new JsonSerializer();
                return ser.Deserialize<JToken>(jsonReader);
            }
        }
    }

    public class CamelCaseOnlyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var token = (JObject)JToken.Load(reader);

            var isCamelCased = true;
            WalkNode(token, null,
                t =>
                {
                    var nameFirstChar = t.Name[0].ToString();
                    if (!nameFirstChar.Equals(nameFirstChar.ToLower(),
                        StringComparison.CurrentCulture))
                    {
                        isCamelCased = false;
                        return;
                    }
                });

            if (!isCamelCased) return null;

            return token.ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            JObject o = (JObject)JToken.FromObject(value);
            o.WriteTo(writer);
        }

        private static void WalkNode(JToken node,
            Action<JObject> objectAction = null,
            Action<JProperty> propertyAction = null)
        {
            if (node.Type == JTokenType.Object)
            {
                if (objectAction != null) objectAction((JObject)node);
                foreach (JProperty child in node.Children<JProperty>())
                {
                    if (propertyAction != null) propertyAction(child);
                    WalkNode(child.Value, objectAction, propertyAction);
                }
            }
            else if (node.Type == JTokenType.Array)
                foreach (JToken child in node.Children())
                    WalkNode(child, objectAction, propertyAction);
        }
    }
}