using DB.Models;
using System.Reflection;
using System;
using System.Text.Json;

namespace Dyplom.Helpers
{
    public static class TypeHelper
    {
        public static T ObjToType<T>(object obj) where T : new()
        {
            T typedObj;

            typedObj = JsonSerializer.Deserialize<T>(((JsonElement)obj).GetRawText());
            
            return typedObj;
        } 
    }
}
