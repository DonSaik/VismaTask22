using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Data.JsonSerDeser;
using VismaTask.Models;

namespace VismaTask.Data
{
    public class CrudMeeting : ICreateMeeting, IReadMeeting
    {
        private IJsonSerializing jsonSerializing = new JsonSerializationDeserialization();
        private IJsonDeserializing jsonDeserializing = new JsonSerializationDeserialization();
        public bool CreateMeeting(List<Meeting> meetingList)
        {
            try
            {
                File.WriteAllText(Globals.JsonFileName, jsonSerializing.CreateJsonSerialization(meetingList));
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Meeting> GetMeetingList()
        {
            List<Meeting> meetingList;
            try
            {
                string jsonString = File.ReadAllText(Globals.JsonFileName);
                meetingList =  jsonDeserializing.GetObjects(jsonString);
                
            }
            catch (Exception ex)
            {
                return null;
            }
            return meetingList;
        }
    }
}
