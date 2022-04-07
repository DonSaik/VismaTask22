using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Utilities
{
    public interface IVerifyAttendee
    {
        bool ExistsInMeeting(Meeting meeting, Attendee attendee);
        public bool IsIntersecting(List<Meeting> meetingList, Meeting meetingWithNewAttendee, Attendee attendee);
    }
}
