﻿using Jose;
using Newtonsoft.Json;

namespace ProductPrice.Domain.Implementation.Services
{
    public class JwtJsonMapper : IJsonMapper
    {
        public string Serialize(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            return JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
        }

        public T Parse<T>(string json)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}