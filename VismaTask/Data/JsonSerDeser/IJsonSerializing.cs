using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Data.JsonSerDeser
{
    public interface IJsonSerializing
    {
        public string CreateJsonSerialization(List<Meeting> obj);
    }
}
