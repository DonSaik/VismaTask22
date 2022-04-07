using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaTask.Models
{
    public class Attendee: Person
    {
        public  DateTime dateTime { get; set; }

        public override string ToString()
        {
            return base.Name + " " + dateTime.ToString();
        }

    }
}
