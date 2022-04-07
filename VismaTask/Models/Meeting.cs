using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaTask.Models
{
    public class Meeting
    {
        public string Name { get; set; }

        public Person ResponsiblePerson { get; set; }
        public string Description { get; set; }

        public List<Attendee> Attendees { get; set; }
        public Category Category { get; set; }
        public MeetingType Type { get; set; }  

        public DateTime  StartDate { get; set; }
        public DateTime EndDate { get; set; } 
    }
}
