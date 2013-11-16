﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class LowercaseJsonSerializer
{
    private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        ContractResolver = new JsonSerializerResolver()
    };

    public static string SerializeObject(object o)
    {
        return JsonConvert.SerializeObject(o, Formatting.Indented, Settings);
    }

    public class JsonSerializerResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}