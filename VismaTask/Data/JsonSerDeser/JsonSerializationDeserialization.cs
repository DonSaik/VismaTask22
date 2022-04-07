using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using VismaTask.Models;

namespace VismaTask.Data.JsonSerDeser
{
    public class JsonSerializationDeserialization: IJsonSerializing, IJsonDeserializing
    {
        public string CreateJsonSerialization(List<Meeting> obj)
        {
            string jsonString = JsonSerializer.Serialize(obj, Globals.JsonSerializationOptions);
            return jsonString;
        }
        public List<Meeting> GetObjects(string jsonString)
        {
            return JsonSerializer.Deserialize<List<Meeting>>(jsonString);
        }
    }
}
