using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RestFull
{
    public static class ToolsEntity<T>
    {
        public static IEnumerable<T> ListFromJson(string json)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var entities = JsonSerializer.Deserialize<List<T>>(json, options);
            return entities;
        }

        public static T ObjetcFromJson(string json)
        {

            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("El json no se puede desealizar");
            }
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var entity = JsonSerializer.Deserialize<T>(json, options);
            return entity;
        }


    }
}
