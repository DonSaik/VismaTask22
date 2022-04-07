using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Data.JsonSerDeser
{
    public interface IJsonDeserializing
    {
        public List<Meeting> GetObjects(string jsonString);
    }
}
