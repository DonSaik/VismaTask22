using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace VismaTask
{
    public static class Globals
    {
        public static JsonSerializerOptions JsonSerializationOptions    
        {
            get
            {
                return new JsonSerializerOptions() { WriteIndented = true }; ;
            } 
        }
        public static string JsonFileName
        {
            get
            {
                return "jsonMeetingData.json";
            }
        }

    }
}
