using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Utilities
{
    public class VerifyAttendee : IVerifyAttendee
    {
        public bool IsIntersecting(List<Meeting> meetingList, Meeting meetingWithNewAttendee, Attendee attendee)
        {
            foreach(Meeting meeting in meetingList)
            {
                if(meeting.Attendees.Contains(attendee))
                    if(meeting != meetingWithNewAttendee)
                    {

                        if(meetingWithNewAttendee.StartDate.CompareTo(meeting.EndDate) > 0)
                        {
                            return true;
                        }
                        else if (meetingWithNewAttendee.EndDate.CompareTo(meeting.StartDate) > 0)
                        {
                            return true;
                        }
                    }
            }
            return false;
        }

        public bool ExistsInMeeting(Meeting meeting, Attendee attendee)
        {
            foreach(Attendee item in meeting.Attendees)
            {
                if (item.Name.Equals(attendee.Name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
